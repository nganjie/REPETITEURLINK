using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using REPETITEURLINK;
using REPETITEURLINK.Entities;
using REPETITEURLINK.Entities.Data;
using REPETITEURLINK.Entities.Extensions;
using REPETITEURLINK.Entities.Models;
using REPETITEURLINK.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace REPETITEURLINK.Services.Security;

/// <summary>
/// Authentication service implementation - Refactored to use Repository exclusively
/// </summary>
[Route("api/auth")]
public class AuthenticationService : BaseRepository, IAuthenticationService
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly JwtSettings _jwtSettings;
    private readonly Google _google;

    public AuthenticationService(
        IRepository repository,
        IJwtTokenService jwtTokenService,
        IOptions<JwtSettings> jwtSettings,
        IOptions<Google> google) : base(repository)
    {
        _jwtTokenService = jwtTokenService;
        _jwtSettings = jwtSettings.Value;
        _google = google.Value;
    }

    /// <inheritdoc />
    public async Task<ApiResponse<LoginResponse?>> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        // Find user by email or phone - Using Repository exclusively
        var login = request.Email.ToLower();
        var user = await _repository.GetAll<User>()
            .Where(x => x.Email.ToLower() == login ||
                        x.PhoneNumber.ToLower() == login)
            .FirstOrDefaultAsync(cancellationToken);



        // Verify password
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return ApiResponse<LoginResponse?>.Failure("User with provided login and password not found");
        }

        // Generate tokens
        var accessToken = _jwtTokenService.GenerateAccessToken(user);
        var refreshToken = _jwtTokenService.GenerateRefreshToken();

        // Update user with refresh token - Using Repository exclusively
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationInDays);
        user.LastLoginAt = DateTime.UtcNow;

        var updateResult = await _repository.UpdateAsync(user);

        if (updateResult == 0)
        {
            return ApiResponse<LoginResponse?>.Failure("Failed to update user session");
        }

        var dto = new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            User = new UserInfo
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                Role = user.Role,
                ParentSubject=user.ParentSubjectType,
                ParentSubjectId=user.ParentSubjectId,
            }
        };

        return ApiResponse<LoginResponse?>.Success(dto);
    }

    /// <inheritdoc />
    public async Task<ApiResponse<LoginResponse?>> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        // Find user by refresh token - Using Repository exclusively
        var user = await _repository.GetAll<User>()
            .Where(u => u.RefreshToken == request.RefreshToken)
            .FirstOrDefaultAsync(cancellationToken);

        // Check if refresh token is expired
        if (user.RefreshTokenExpiryTime == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return ApiResponse<LoginResponse?>.Failure("Refresh token has expired");
        }

        // Generate new tokens
        var accessToken = _jwtTokenService.GenerateAccessToken(user);
        var newRefreshToken = _jwtTokenService.GenerateRefreshToken();

        // Update user with new refresh token - Using Repository exclusively
        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationInDays);

        var updateResult = await _repository.UpdateAsync(user);

        if (updateResult == 0)
        {
            return ApiResponse<LoginResponse?>.Failure("Failed to refresh token");
        }

        var dto = new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            User = new UserInfo
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                Role = user.Role,
                ParentSubject=user.ParentSubjectType,
                ParentSubjectId=user.ParentSubjectId
            }
        };

        return ApiResponse<LoginResponse?>.Success(dto);
    }
    // Alternative: API endpoint pour mobile/applications natives
    [HttpPost("google")]
    public async Task<ApiResponse<UserDto?>> GoogleLoginMobile([FromBody] GoogleAuthRequest request)
    {
        // Valider le token Google côté serveur
        var payload = await ValidateGoogleToken(request.IdToken);

        if (payload == null)
        {
            return ApiResponse<UserDto?>.Failure("Invalid Google token");
        }

        var user = await _repository.GetAll<User>()
            .FirstOrDefaultAsync(u => u.GoogleId == Guid.Parse(payload.Subject) || u.Email == payload.Email);

        if (user == null)
        {
            user = new User
            {
                Email = payload.Email,
                GoogleId = Guid.Parse(payload.Subject),
                FirstName = payload.GivenName,
                LastName = payload.FamilyName,
                //ProfilePicture = payload.Picture,
                CreatedAt = DateTime.UtcNow,
                LastLoginAt = DateTime.UtcNow
            };

            await _repository.InsertAsync(user);
        }
        var dto = await _repository.GetAll<User>()
            //.IncludeRelatives()
            .Where(x => x.Id == user.Id).Select(x => x.ToDto()).FirstOrDefaultAsync();

        return ApiResponse<UserDto>.Success(dto);
    }

    private async Task<GoogleJsonWebSignature.Payload> ValidateGoogleToken(string idToken)
    {
        try
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new[] { _google.ClientId }
            };

            return await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
        }
        catch
        {
            return null;
        }
    }

    /// <inheritdoc />
    public async Task<ApiResponse<bool>> ChangePasswordAsync(Guid userId, ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        // Find user by ID - Using Repository exclusively
        var user = await _repository.GetAll<User>()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            return ApiResponse<bool>.Failure("user not found");
        }

        // Verify current password
        if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.Password))
        {
            return ApiResponse<bool>.Failure("current password is incorrect");
        }

        // Hash new password
        user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

        // Update user - Using Repository exclusively
        var updateResult = await _repository.UpdateAsync(user);

        if (updateResult == 0)
        {
            return ApiResponse<bool>.Failure("Failed to update password");
        }

        return ApiResponse<bool>.Success(true);
    }

    /// <inheritdoc />
    public async Task<ApiResponse<bool>> LogoutAsync(Guid userId, CancellationToken cancellationToken)
    {
        // Find user by ID - Using Repository exclusively
        var user = await _repository.GetAll<User>()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            return ApiResponse<bool>.Failure("user not found");
        }

        // Clear refresh token - Using Repository exclusively
        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = null;

        var updateResult = await _repository.UpdateAsync(user);

        if (updateResult == 0)
        {
            return ApiResponse<bool>.Failure("Failed to logout");
        }

        return ApiResponse<bool>.Success(true);
    }

    /// <inheritdoc />
    public async Task<ApiResponse<UserDto>> RegisterUserAsync(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        // Check if user already exists - Using Repository exclusively
        var existingUser = await _repository.GetAll<User>()
            .Where(u => u.Email.ToLower() == request.Email.ToLower())
            .FirstOrDefaultAsync(cancellationToken);

        if (existingUser != null)
        {
            throw new InvalidOperationException("User with this email already exists");
        }

        // Parse role
        if (!Enum.TryParse<UserRoles>(request.Role, out var role))
        {
            throw new ArgumentException("Invalid role specified");
        }
        UserSubjectType parentSubjectType = UserSubjectType.None;
        if (role == UserRoles.Student)
        {
            parentSubjectType = UserSubjectType.Student;
        }
        if (role == UserRoles.Parent)
        {
            parentSubjectType = UserSubjectType.Parent;
        }
        if (role == UserRoles.Teacher)
        {
            parentSubjectType = UserSubjectType.Encadreur;
        }

        // Create new user
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email.ToLower(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            ParentSubjectType=parentSubjectType,
            ParentSubjectId=request.ParentSubjectId,
            Role = role,
            CreatedAt = DateTime.UtcNow,
        };

        // Insert user - Using Repository exclusively
        var insertResult = await _repository.InsertAsync(user);

        if (insertResult == 0)
        {
            throw new InvalidOperationException("Failed to create user");
        }

        var dto = await _repository.GetAll<User>()
            //.IncludeRelatives()
            .Where(x => x.Id == user.Id).Select(x => x.ToDto()).FirstOrDefaultAsync();

        return ApiResponse<UserDto>.Success(dto);
    }
}