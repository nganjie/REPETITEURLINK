using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class Parent:EntityBase
{
    public Guid? UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}

public class ParentDto:EntityBase
{
    public Guid? UserId { get; set; }
    public UserDto User { get; set; }
}