using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class Encadreur:BaseUserEntity
{
    public string? UserId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsCertified { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; } = null;
    public List<SubjectEncadreur> Subjects { get; set; }
}
