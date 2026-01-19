using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

    public class BaseUserEntity:EntityBase
    {
    public Guid? CityId { get; set; }
    [MaxLength(50)]
    public string? FirstName { get; set; }
    [MaxLength(50)]
    public string ?LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}".Trim();
    public string Email { get; set; }
    public Gender Sexe { get; set; }
    public string Password { get; set; }
    [MaxLength(12)]
    public string PhoneNumber { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public DateTime? LastLoginAt { get; set; }

    [ForeignKey(nameof(CityId))]
    public DirectoryItem? City { get; set; }
    public string? EmailAddress { get; set; } = null;
    public bool IsEmailVerified { get; set; } = false;
    public DateTime? EmailVerifiedOn { get; set; }
}

