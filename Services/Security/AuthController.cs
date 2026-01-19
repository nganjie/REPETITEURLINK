using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REPETITEURLINK.Entities;
using REPETITEURLINK.Entities.Data;
using REPETITEURLINK.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace REPETITEURLINK.Services.Security;

/// <summary>
/// Authentication controller for user login, logout, and token management
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthController : BaseSharedController
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<AuthController> _logger;
    private readonly IRepository _repository;

    public AuthController(IHttpContextAccessor accessor,
        IAuthenticationService authenticationService,
        IRepository repository,
        ILogger<AuthController> logger):base(accessor,repository)
    {
        _authenticationService = authenticationService;
        _logger = logger;
        _repository = repository;
    }

    /// <summary>
    /// Authenticates a user and returns JWT tokens
    /// </summary>
    /// <param name="request">Login credentials</param>
    /// <returns>Login response with access and refresh tokens</returns>
    /// <response code="200">Login successful</response>
    /// <response code="400">Invalid request</response>
    /// <response code="401">Invalid credentials</response>
    [HttpPost("login")]
    [AllowAnonymous]
    //[ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ApiResponse<LoginResponse?>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        _logger.LogInformation("Login attempt for user: {Email}", request.Email);

        var response = await _authenticationService.LoginAsync(request,cancellationToken);

       

        _logger.LogInformation("User logged in successfully: {Email}", request.Email);

        return response;
    }

    /// <summary>
    /// Refreshes an access token using a refresh token
    /// </summary>
    /// <param name="request">Refresh token request</param>
    /// <returns>New login response with fresh tokens</returns>
    /// <response code="200">Token refreshed successfully</response>
    /// <response code="400">Invalid request</response>
    /// <response code="401">Invalid or expired refresh token</response>
    [HttpPost("refresh-token")]
    [AllowAnonymous]
    //[ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ApiResponse<LoginResponse?>> RefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        _logger.LogInformation("Refresh token attempt");

        var response = await _authenticationService.RefreshTokenAsync(request,cancellationToken);

        //if (response == null)
        //{
        //    _logger.LogWarning("Failed refresh token attempt");
        //    return Unauthorized(new { message = "Invalid or expired refresh token" });
        //}

        _logger.LogInformation("Token refreshed successfully for user: {UserId}", response.Data?.User.Id);

        return response;
    }

    /// <summary>
    /// Logs out the current user by invalidating their refresh token
    /// </summary>
    /// <returns>Success message</returns>
    /// <response code="200">Logout successful</response>
    /// <response code="401">Unauthorized</response>
    [HttpPost("logout")]
    [Authorize]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ApiResponse<bool>> Logout( CancellationToken cancellationToken)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
        {
            return ApiResponse<bool>.Failure("Unauhorized");
        }

        _logger.LogInformation("Logout request for user: {UserId}", userId);

       var response= await _authenticationService.LogoutAsync(userId,cancellationToken);

        _logger.LogInformation("User logged out successfully: {UserId}", userId);

        return response;
    }

    /// <summary>
    /// Changes the password for the current user
    /// </summary>
    /// <param name="request">Change password request</param>
    /// <returns>Success message</returns>
    /// <response code="200">Password changed successfully</response>
    /// <response code="400">Invalid request or current password incorrect</response>
    /// <response code="401">Unauthorized</response>
    [HttpPost("change-password")]
    [Authorize]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ApiResponse<bool>> ChangePassword([FromBody] ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
        {
            return ApiResponse<bool>.Failure("Unauhorized");
        }

        _logger.LogInformation("Password change request for user: {UserId}", userId);

        var success = await _authenticationService.ChangePasswordAsync(userId, request,cancellationToken);

        if (!success.IsSuccess)
        {
            _logger.LogWarning("Failed password change for user: {UserId}", userId);
           // return BadRequest(new { message = "Current password is incorrect" });
        }

        _logger.LogInformation("Password changed successfully for user: {UserId}", userId);

        return success;
    }

    /// <summary>
    /// Registers a new user (SuperAdmin only)
    /// </summary>
    /// <param name="request">Register user request</param>
    /// <returns>Created user information</returns>
    /// <response code="201">User created successfully</response>
    /// <response code="400">Invalid request or user already exists</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden - requires SuperAdmin role</response>
    [HttpPost("register")]
    [Authorize(Roles = "SuperAdmin")]
    //[ProducesResponseType(typeof(UserInfo), StatusCodes.Status201Created)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //[ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ApiResponse<UserDto>> Register([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        try
        {
            _logger.LogInformation("User registration attempt for email: {Email}", request.Email);

            var userInfo = await _authenticationService.RegisterUserAsync(request, cancellationToken);

            _logger.LogInformation("User registered successfully: {Email}", request.Email);

            return userInfo;
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning("User registration failed: {Message}", ex.Message);
            ApiResponse<UserInfo>.Failure("User registration failed");
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning("Invalid registration data: {Message}", ex.Message);
            return ApiResponse<UserDto>.Failure("Invalid registration data");
        }

        return ApiResponse<UserDto>.Failure("internal error");
    }

    /// <summary>
    /// Gets the current authenticated user's information
    /// </summary>
    /// <returns>Current user information</returns>
    /// <response code="200">User information retrieved</response>
    /// <response code="401">Unauthorized</response>
    [HttpGet("current-user")]
    [Authorize]
    //[ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public UserInfo? GetCurrentUser() => this.CurrentUser;
    
    
}
