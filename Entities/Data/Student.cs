using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class Student:BaseUserEntity
{
    public string? UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
}
