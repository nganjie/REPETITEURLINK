using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

    public class BaseUserEntity:EntityBase
    {
    public string? CityId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public Gender Sexe { get; set; }
    public string Password { get; set; }
    [MaxLength(12)]
    public string PhoneNumber { get; set; }

    [ForeignKey(nameof(CityId))]
    public DirectoryItem? City { get; set; }
}

