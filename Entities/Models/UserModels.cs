using System.ComponentModel.DataAnnotations;

namespace REPETITEURLINK.Entities.Models;

/// <summary>
/// Model for creating a new user (delegates to AuthenticationService.RegisterUserAsync)
/// </summary>
public record CreateUserModel
{
    /// <summary>
    /// User's email address (used for login)
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(200)]
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// User's password
    /// </summary>
    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 100 characters")]
    public string Password { get; init; } = string.Empty;

    /// <summary>
    /// User's first name
    /// </summary>
    [Required(ErrorMessage = "First name is required")]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; init; } = string.Empty;

    /// <summary>
    /// User's last name
    /// </summary>
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(100, MinimumLength = 2)]
    public string LastName { get; init; } = string.Empty;

    /// <summary>
    /// User role (SuperAdmin, Director, Secretary, Teacher, Parent, Student, Accountant)
    /// </summary>
    [Required(ErrorMessage = "Role is required")]
    public string Role { get; init; } = string.Empty;

    /// <summary>
    /// Preferred language (fr or en)
    /// </summary>
    [Required]
    [RegularExpression("^(fr|en)$", ErrorMessage = "Language must be 'fr' or 'en'")]
    public string PreferredLanguage { get; init; } = "fr";

    /// <summary>
    /// Organization ID (optional for SuperAdmin)
    /// </summary>
    public Guid? OrganizationId { get; init; }

    /// <summary>
    /// School IDs for this user (for teachers, directors, etc.)
    /// </summary>
    public IReadOnlyList<Guid> SchoolIds { get; init; } = Array.Empty<Guid>();

    /// <summary>
    /// Phone number (optional)
    /// </summary>
    [Phone]
    [StringLength(20)]
    public string? Phone { get; init; }
}

/// <summary>
/// Model for updating an existing user
/// </summary>
public record UpdateUserModel
{
    /// <summary>
    /// Updated first name (optional)
    /// </summary>
    [StringLength(100, MinimumLength = 2)]
    public string? FirstName { get; init; }

    /// <summary>
    /// Updated last name (optional)
    /// </summary>
    [StringLength(100, MinimumLength = 2)]
    public string? LastName { get; init; }

    /// <summary>
    /// Updated phone number (optional)
    /// </summary>
    [Phone]
    [StringLength(20)]
    public string? Phone { get; init; }

    /// <summary>
    /// Updated preferred language (optional)
    /// </summary>
    [RegularExpression("^(fr|en)$")]
    public string? PreferredLanguage { get; init; }

    /// <summary>
    /// Updated school IDs (optional, replaces entire list)
    /// </summary>
    public IReadOnlyList<Guid>? SchoolIds { get; init; }
}

/// <summary>
/// Model for updating a user's role
/// </summary>
public record UpdateUserRoleModel
{
    /// <summary>
    /// New role to assign
    /// </summary>
    [Required(ErrorMessage = "Role is required")]
    public string Role { get; init; } = string.Empty;

    /// <summary>
    /// New organization ID (optional)
    /// </summary>
    public Guid? OrganizationId { get; init; }

    /// <summary>
    /// New school IDs (optional)
    /// </summary>
    public IReadOnlyList<Guid>? SchoolIds { get; init; }
}

/// <summary>
/// Model for searching users
/// </summary>
public record SearchUsersModel
{
    /// <summary>
    /// Search by name or email
    /// </summary>
    [StringLength(200)]
    public string? Search { get; init; }

    /// <summary>
    /// Filter by role
    /// </summary>
    public string? Role { get; init; }

    /// <summary>
    /// Filter by organization ID
    /// </summary>
    public Guid? OrganizationId { get; init; }

    /// <summary>
    /// Filter by school ID
    /// </summary>
    public Guid? SchoolId { get; init; }

    /// <summary>
    /// Filter by user status
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// Page number
    /// </summary>
    [Range(1, int.MaxValue)]
    public int Page { get; init; } = 1;

    /// <summary>
    /// Page size
    /// </summary>
    [Range(1, 100)]
    public int PageSize { get; init; } = 20;

    /// <summary>
    /// Sort field
    /// </summary>
    [StringLength(50)]
    public string SortBy { get; init; } = "LastName";

    /// <summary>
    /// Sort direction
    /// </summary>
    [RegularExpression("^(asc|desc)$")]
    public string SortDirection { get; init; } = "asc";

    /// <summary>
    /// Calculate offset
    /// </summary>
    public int Offset => (Page - 1) * PageSize;

    /// <summary>
    /// Get limit
    /// </summary>
    public int Limit => PageSize;
}
