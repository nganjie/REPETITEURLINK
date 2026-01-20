using REPETITEURLINK.Entities;
using REPETITEURLINK.Entities.Data;
using REPETITEURLINK.Entities.Models;
using REPETITEURLINK.Services.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace REPETITEURLINK.Services.Contracts;

/// <summary>
/// Service contract for user management operations
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Create a new user (delegates to AuthenticationService)
    /// </summary>
    Task<ApiResponse<UserDto>> CreateUserAsync(
        CreateUserModel model,
        UserInfo currentUser,
        CancellationToken cancellationToken);

    /// <summary>
    /// Get user details by ID
    /// </summary>
    Task<ApiResponse<UserDto>> GetUserDetailsAsync(
        Guid userId,
        UserInfo currentUser,
        CancellationToken cancellationToken);

    /// <summary>
    /// Update user information
    /// </summary>
    Task<ApiResponse<UserDto>> UpdateUserAsync(
        UpdateUserModel model,
        Guid userId,
        UserInfo currentUser,
        CancellationToken cancellationToken);

    /// <summary>
    /// Soft delete a user
    /// </summary>
    Task<ApiResponse<UserDto>> DeleteUserAsync(
        Guid userId,
        UserInfo currentUser,
        CancellationToken cancellationToken);

    /// <summary>
    /// Activate or deactivate a user
    /// </summary>
    Task<ApiResponse<UserDto>> UpdateUserStatusAsync(
        Guid userId,
        bool isActive,
        UserInfo currentUser,
        CancellationToken cancellationToken);

    /// <summary>
    /// Update user role and permissions
    /// </summary>
    Task<ApiResponse<UserDto>> UpdateUserRoleAsync(
        UpdateUserRoleModel model,
        Guid userId,
        UserInfo currentUser,
        CancellationToken cancellationToken);

    /// <summary>
    /// Search users with filters
    /// </summary>
    Task<ApiResponse<PaginatedResponse<UserDto>>> SearchUsersAsync(
        SearchUsersModel searchModel,
        UserInfo currentUser,
        CancellationToken cancellationToken);

    /// <summary>
    /// Get all users in an organization
    /// </summary>
    Task<ApiResponse<UserDto[]>> GetUsersByOrganizationAsync(
        Guid organizationId,
        UserInfo currentUser,
        CancellationToken cancellationToken);

    

}