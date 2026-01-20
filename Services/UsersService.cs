using Microsoft.EntityFrameworkCore;
using REPETITEURLINK.Services.Contracts;
using REPETITEURLINK.Services.Queues;
using REPETITEURLINK.Entities;
using REPETITEURLINK.Entities.Data;
using REPETITEURLINK.Entities.Extensions;
using REPETITEURLINK.Entities.Models;
using REPETITEURLINK.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using REPETITEURLINK.Services.Security;

namespace REPETITEURLINK.Services;

/// <summary>
/// Service for managing users with CRUD operations, role management, and authentication integration
/// </summary>
public class UsersService : BaseRepository, IUsersService
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<UsersService> _logger;

    public UsersService(
        IRepository repository,
        AppConfiguration config,
        IAuthenticationService authenticationService,
        ILogger<UsersService> logger)
        : base(repository, config)
    {
        _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    #region Create User (delegates to AuthenticationService)

    /// <inheritdoc />
    public async Task<ApiResponse<UserDto>> CreateUserAsync(
        CreateUserModel model,
        UserInfo currentUser,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation(
                "Creating user {Email} with role {Role} by user {UserId}",
                model.Email,
                model.Role,
                currentUser.Id
            );

            // 1. Validate permissions
            if (!CanUserManageUsers(currentUser))
            {
                _logger.LogWarning(
                    "User {UserId} does not have permission to create users",
                    currentUser.Id
                );
                return ApiResponse<UserDto>.Failure("Insufficient permissions", 403);
            }

            // 2. Delegate to AuthenticationService for user creation
            var registerRequest = new RegisterUserRequest
            {
                Email = model.Email,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = model.Role,
                PhoneNumber = model.Phone,
                
            };

            var response = await _authenticationService.RegisterUserAsync(registerRequest,CancellationToken.None);
            var userInfo = response.Data;
           
            _logger.LogInformation("Successfully created user {UserId} - {Email}", userInfo.Id, userInfo.Email);

            return await GetUserDetailsAsync(userInfo.Id, currentUser, cancellationToken);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Invalid operation creating user");
            return ApiResponse<UserDto>.Failure(ex.Message, 400);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid argument creating user");
            return ApiResponse<UserDto>.Failure(ex.Message, 400);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error creating user");
            return ApiResponse<UserDto>.Failure("An unexpected error occurred", 500);
        }
    }

    #endregion

    #region Get User Details

    /// <inheritdoc />
    public async Task<ApiResponse<UserDto>> GetUserDetailsAsync(
        Guid userId,
        UserInfo currentUser,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug("Getting user details for {UserId}", userId);

            var user = await _repository.GetAll<User>()
                .Where(u => u.Id == userId)
                .Select(u => u.ToDto())
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                _logger.LogWarning("User {UserId} not found", userId);
                return ApiResponse<UserDto>.Failure("User not found", 404);
            }

            // Validate permissions
            if (!CanUserAccessUser(currentUser))
            {
                _logger.LogWarning(
                    "User {UserId} does not have permission to access user {TargetUserId}",
                    currentUser.Id,
                    userId
                );
                return ApiResponse<UserDto>.Failure("Insufficient permissions", 403);
            }

            return ApiResponse<UserDto>.Success(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting user details for {UserId}", userId);
            return ApiResponse<UserDto>.Failure("An error occurred", 500);
        }
    }

    #endregion

    #region Update User

    /// <inheritdoc />
    public async Task<ApiResponse<UserDto>> UpdateUserAsync(
        UpdateUserModel model,
        Guid userId,
        UserInfo currentUser,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Updating user {UserId} by user {CurrentUserId}", userId, currentUser.Id);

            // 1. Get existing user
            var user = await _repository.GetAll<User>()
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user == null)
            {
                _logger.LogWarning("User {UserId} not found for update", userId);
                return ApiResponse<UserDto>.Failure("User not found", 404);
            }

            // 2. Validate permissions
            if (!CanUserManageUsers(currentUser))
            {
                _logger.LogWarning(
                    "User {UserId} does not have permission to update user {TargetUserId}",
                    currentUser.Id,
                    userId
                );
                return ApiResponse<UserDto>.Failure("Insufficient permissions", 403);
            }

            // 3. Update fields
            if (!string.IsNullOrWhiteSpace(model.FirstName))
            {
                user.FirstName = model.FirstName.Trim();
            }

            if (!string.IsNullOrWhiteSpace(model.LastName))
            {
                user.LastName = model.LastName.Trim();
            }

            if (!string.IsNullOrWhiteSpace(model.Phone))
            {
                user.PhoneNumber = model.Phone.Trim();
            }

            user.UpdatedAt = DateTime.UtcNow;

            // 4. Save changes
            var updateResult = await _repository.UpdateAsync(user);
            if (updateResult == 0)
            {
                _logger.LogError("Failed to update user {UserId}", userId);
                return ApiResponse<UserDto>.Failure("Failed to update user", 500);
            }

            // 5. Get updated user
            var updatedUser = await GetUserDetailsAsync(userId, currentUser, cancellationToken);

            _logger.LogInformation("Successfully updated user {UserId}", userId);

            return updatedUser;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Database error updating user {UserId}", userId);
            return ApiResponse<UserDto>.Failure("Database error occurred", 500);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error updating user {UserId}", userId);
            return ApiResponse<UserDto>.Failure("An unexpected error occurred", 500);
        }
    }

    #endregion

    #region Delete User

    /// <inheritdoc />
    public async Task<ApiResponse<UserDto>> DeleteUserAsync(
        Guid userId,
        UserInfo currentUser,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Deleting user {UserId} by user {CurrentUserId}", userId, currentUser.Id);

            // 1. Get user
            var user = await _repository.GetAll<User>()
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user == null)
            {
                _logger.LogWarning("User {UserId} not found for deletion", userId);
                return ApiResponse<UserDto>.Failure("User not found", 404);
            }

            // 2. Validate permissions (only SuperAdmin can delete users)
            if (currentUser.Role != UserRoles.SuperAdmin)
            {
                _logger.LogWarning(
                    "User {UserId} does not have permission to delete users",
                    currentUser.Id
                );
                return ApiResponse<UserDto>.Failure("Insufficient permissions", 403);
            }

            // 3. Prevent self-deletion
            if (user.Id == currentUser.Id)
            {
                _logger.LogWarning("User {UserId} attempted to delete themselves", userId);
                return ApiResponse<UserDto>.Failure("Cannot delete your own account", 400);
            }
            user.IsDeleted = true;
            user.DeletedOn = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            var updateResult = await _repository.UpdateAsync(user);
            if (updateResult == 0)
            {
                _logger.LogError("Failed to delete user {UserId}", userId);
                return ApiResponse<UserDto>.Failure("Failed to delete user", 500);
            }

            

            _logger.LogInformation("Successfully deleted user {UserId}", userId);

            return await GetUserDetailsAsync(userId, currentUser, cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Database error deleting user {UserId}", userId);
            return ApiResponse<UserDto>.Failure("Database error occurred", 500);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error deleting user {UserId}", userId);
            return ApiResponse<UserDto>.Failure("An unexpected error occurred", 500);
        }
    }

    #endregion

    #region Update User Status

    /// <inheritdoc />
    public async Task<ApiResponse<UserDto>> UpdateUserStatusAsync(
        Guid userId,
        bool isActive,
        UserInfo currentUser,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation(
                "Updating user {UserId} status to {IsActive} by user {CurrentUserId}",
                userId,
                isActive,
                currentUser.Id
            );

            // 1. Get user
            var user = await _repository.GetAll<User>()
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user == null)
            {
                _logger.LogWarning("User {UserId} not found for status update", userId);
                return ApiResponse<UserDto>.Failure("User not found", 404);
            }

            // 2. Validate permissions (only SuperAdmin and Director)
            if (currentUser.Role != UserRoles.SuperAdmin)
            {
                _logger.LogWarning(
                    "User {UserId} does not have permission to update user status",
                    currentUser.Id
                );
                return ApiResponse<UserDto>.Failure("Insufficient permissions", 403);
            }

            // 3. Prevent self-deactivation
            if (user.Id == currentUser.Id && !isActive)
            {
                _logger.LogWarning("User {UserId} attempted to deactivate themselves", userId);
                return ApiResponse<UserDto>.Failure("Cannot deactivate your own account", 400);
            }

            user.UpdatedAt = DateTime.UtcNow;

            var updateResult = await _repository.UpdateAsync(user);
            if (updateResult == 0)
            {
                _logger.LogError("Failed to update user {UserId} status", userId);
                return ApiResponse<UserDto>.Failure("Failed to update user status", 500);
            }

            // 5. Get updated user
            //var userDetails = new UserDetailsDto
            //{
            //    Id = user.Id,
            //    Email = user.Email,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    Role = user.Role,
            //    PreferredLanguage = user.PreferredLanguage,
            //    Phone = user.Phone,
            //    OrganizationId = user.OrganizationId,
            //    SchoolIds = user.SchoolIds.ToList(),
            //    State = user.State,
            //    CreatedAt = user.CreatedAt,
            //    UpdatedAt = user.UpdatedAt
            //};

            _logger.LogInformation("Successfully updated user {UserId} status", userId);

            return await GetUserDetailsAsync(userId, currentUser, cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Database error updating user {UserId} status", userId);
            return ApiResponse<UserDto>.Failure("Database error occurred", 500);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error updating user {UserId} status", userId);
            return ApiResponse<UserDto>.Failure("An unexpected error occurred", 500);
        }
    }

    #endregion

    #region Update User Role

    /// <inheritdoc />
    public async Task<ApiResponse<UserDto>> UpdateUserRoleAsync(
        UpdateUserRoleModel model,
        Guid userId,
        UserInfo currentUser,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation(
                "Updating user {UserId} role to {Role} by user {CurrentUserId}",
                userId,
                model.Role,
                currentUser.Id
            );

            // 1. Validate permissions (only SuperAdmin can change roles)
            if (currentUser.Role != UserRoles.SuperAdmin)
            {
                _logger.LogWarning(
                    "User {UserId} does not have permission to update user roles",
                    currentUser.Id
                );
                return ApiResponse<UserDto>.Failure("Insufficient permissions", 403);
            }

            // 2. Get user
            var user = await _repository.GetAll<User>()
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user == null)
            {
                _logger.LogWarning("User {UserId} not found for role update", userId);
                return ApiResponse<UserDto>.Failure("User not found", 404);
            }

            // 3. Validate role
            if (!Enum.TryParse<UserRoles>(model.Role, out var newRole))
            {
                _logger.LogWarning("Invalid role {Role} specified", model.Role);
                return ApiResponse<UserDto>.Failure("Invalid role specified", 400);
            }

            // 4. Update role and related fields
            user.Role = newRole;

            user.UpdatedAt = DateTime.UtcNow;

            // 5. Save changes
            var updateResult = await _repository.UpdateAsync(user);
            if (updateResult == 0)
            {
                _logger.LogError("Failed to update user {UserId} role", userId);
                return ApiResponse<UserDto>.Failure("Failed to update user role", 500);
            }

            // 6. Get updated user
            var updatedUser = await GetUserDetailsAsync(userId, currentUser, cancellationToken);

            _logger.LogInformation("Successfully updated user {UserId} role to {Role}", userId, model.Role);

            return updatedUser;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Database error updating user {UserId} role", userId);
            return ApiResponse<UserDto>.Failure("Database error occurred", 500);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error updating user {UserId} role", userId);
            return ApiResponse<UserDto>.Failure("An unexpected error occurred", 500);
        }
    }

    #endregion

    #region Search Users

    /// <inheritdoc />
    public async Task<ApiResponse<PaginatedResponse<UserDto>>> SearchUsersAsync(
        SearchUsersModel searchModel,
        UserInfo currentUser,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug(
                "Searching users with search={Search}, role={Role}, limit={Limit}, offset={Offset}",
                searchModel.Search,
                searchModel.Role,
                searchModel.Limit,
                searchModel.Offset
            );

            // Validate pagination
            if (searchModel.Limit <= 0 || searchModel.Limit > 100)
            {
                return ApiResponse<PaginatedResponse<UserDto>>.Failure(
                    "Limit must be between 1 and 100",
                    400
                );
            }

            if (searchModel.Offset < 0)
            {
                return ApiResponse<PaginatedResponse<UserDto>>.Failure(
                    "Offset must be non-negative",
                    400
                );
            }

            var query = _repository.GetAll<User>().AsQueryable();

            // Filter by organization if not SuperAdmin
            if (currentUser.Role != UserRoles.SuperAdmin )
            {
               // query = query.Where(u => u.OrganizationId == currentUser.OrganizationId.Value);
            }

            // Apply filters
            if (!string.IsNullOrWhiteSpace(searchModel.Search))
            {
                var searchLower = searchModel.Search.ToLower();
                query = query.Where(u =>
                    u.FirstName.ToLower().Contains(searchLower) ||
                    u.LastName.ToLower().Contains(searchLower) ||
                    u.Email.ToLower().Contains(searchLower)
                );
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Role))
            {
                if (Enum.TryParse<UserRoles>(searchModel.Role, out var roleEnum))
                {
                    query = query.Where(u => u.Role == roleEnum);
                }
            }

            // Get total count
            var total = await query.CountAsync(cancellationToken);

            // Apply sorting
            query = searchModel.SortDirection.ToLower() == "desc"
                ? query.OrderByDescending(u => EF.Property<object>(u, searchModel.SortBy))
                : query.OrderBy(u => EF.Property<object>(u, searchModel.SortBy));

            // Apply pagination
            var users = await query
                .Skip(searchModel.Offset)
                .Take(searchModel.Limit)
                .Select(u => u.ToDto())
                .ToArrayAsync(cancellationToken);

            var response = new PaginatedResponse<UserDto>
            {
                Data = users,
                Meta = new PageMeta
                {
                    Total = total,
                    Limit = searchModel.Limit,
                    Offset = searchModel.Offset
                }
            };

            return ApiResponse<PaginatedResponse<UserDto>>.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error searching users");
            return ApiResponse<PaginatedResponse<UserDto>>.Failure("An error occurred", 500);
        }
    }

    #endregion

    #region Get Users By Organization

    /// <inheritdoc />
    public async Task<ApiResponse<UserDto[]>> GetUsersByOrganizationAsync(
        Guid organizationId,
        UserInfo currentUser,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug("Getting users for organization {OrgId}", organizationId);

            // Validate permissions
            if (!CanUserAccessUser(currentUser))
            {
                _logger.LogWarning(
                    "User {UserId} does not have permission to access organization {OrgId}",
                    currentUser.Id,
                    organizationId
                );
                return ApiResponse<UserDto[]>.Failure("Insufficient permissions", 403);
            }

            var users = await _repository.GetAll<User>()
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => u.ToDto())
                .ToArrayAsync(cancellationToken);

            return ApiResponse<UserDto[]>.Success(users);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting users for organization {OrgId}", organizationId);
            return ApiResponse<UserDto[]>.Failure("An error occurred", 500);
        }
    }

    #endregion



    #region Private Helper Methods

    /// <summary>
    /// Checks if a user can manage (create/update/delete) other users
    /// </summary>
    private bool CanUserManageUsers(UserInfo currentUser)
    {
        // SuperAdmin can manage all users
        if (currentUser.Role == UserRoles.SuperAdmin)
        {
            return true;
        }

        // Director can manage users in their organization

        return false;
    }

    /// <summary>
    /// Checks if a user can access (read) another user
    /// </summary>
    private bool CanUserAccessUser(UserInfo currentUser)
    {
        // SuperAdmin can access all users
        if (currentUser.Role == UserRoles.SuperAdmin)
        {
            return true;
        }

        return false;
    }

    #endregion
}