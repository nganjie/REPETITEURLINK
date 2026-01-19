using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class Encadreur:EntityBase
{
    public Guid UserId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsCertified { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

}


public class  EncadreurDto:EntityBase
{
    public Guid UserId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsCertified { get; set; }
    public UserDto User { get; set; }
}