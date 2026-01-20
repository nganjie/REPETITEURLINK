using System;
using System.Collections.Generic;
using System.Text;

namespace REPETITEURLINK.Services.Security;

using REPETITEURLINK.Entities.Data;
using System.ComponentModel.DataAnnotations;
/// <summary>
/// Login request DTO
/// </summary>
public record LoginRequest
{
    /// <summary>
    /// User's email address
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// User's password
    /// </summary>
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; init; } = string.Empty;
}

/// <summary>
/// Login response DTO
/// </summary>
public record LoginResponse
{
    /// <summary>
    /// JWT access token
    /// </summary>
    public string AccessToken { get; init; } = string.Empty;

    /// <summary>
    /// Refresh token for obtaining new access tokens
    /// </summary>
    public string RefreshToken { get; init; } = string.Empty;

    /// <summary>
    /// Token expiration timestamp
    /// </summary>
    public DateTime ExpiresAt { get; init; }

    /// <summary>
    /// Authenticated user information
    /// </summary>
    public UserInfo User { get; init; } = null!;
}

/// <summary>
/// User information DTO
/// </summary>
public record UserInfo
{
    /// <summary>
    /// User's unique identifier
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// User's email address
    /// </summary>
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// User's first name
    /// </summary>
    public string FirstName { get; init; } = string.Empty;

    /// <summary>
    /// User's last name
    /// </summary>
    public string LastName { get; init; } = string.Empty;

    /// <summary>
    /// User's full name
    /// </summary>
    public string FullName { get; init; } = string.Empty;

    /// <summary>
    /// User's role in the system
    /// </summary>
    public UserRoles Role { get; init; } 
    public Guid? ParentSubjectId { get; set;  }
    public UserSubjectType ParentSubjectType { get; set; }
    public object ParentSubject { get; set; }
}

/// <summary>
/// Refresh token request DTO
/// </summary>
public record RefreshTokenRequest
{
    /// <summary>
    /// Refresh token
    /// </summary>
    [Required(ErrorMessage = "Refresh token is required")]
    public string RefreshToken { get; init; } = string.Empty;
}

/// <summary>
/// Change password request DTO
/// </summary>
public record ChangePasswordRequest
{
    /// <summary>
    /// Current password
    /// </summary>
    [Required(ErrorMessage = "Current password is required")]
    public string CurrentPassword { get; init; } = string.Empty;

    /// <summary>
    /// New password
    /// </summary>
    [Required(ErrorMessage = "New password is required")]
    [MinLength(8, ErrorMessage = "New password must be at least 8 characters")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
    public string NewPassword { get; init; } = string.Empty;
}

/// <summary>
/// Register user request DTO
/// </summary>
public record RegisterUserRequest
{
    /// <summary>
    /// Email address
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// Password
    /// </summary>
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; init; } = string.Empty;

    /// <summary>
    /// First name
    /// </summary>
    //[Required(ErrorMessage = "First name is required")]
    [MaxLength(100)]
    public string FirstName { get; init; } = string.Empty;

    /// <summary>
    /// Last name
    /// </summary>
    //[Required(ErrorMessage = "Last name is required")]
    [MaxLength(100)]
    public string LastName { get; init; } = string.Empty;

    /// <summary>
    /// User role
    /// </summary>
    [Required(ErrorMessage = "Role is required")]
    public string Role { get; init; } = string.Empty;


    /// <summary>
    /// Organization ID (optional, required for non-SuperAdmin roles)
    /// </summary>
    [Required(ErrorMessage = "City  is required")]
    public Guid? CityId { get; init; }
    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    public string PhoneNumber { get; init; } = string.Empty;
    public Guid? ParentSubjectId { get; init; }
}

