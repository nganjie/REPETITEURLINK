using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class Student:EntityBase
{
    public Guid UserId { get; set; }
    public Guid SchoolLevelId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    [ForeignKey(nameof(SchoolLevelId))]
    public DirectoryItem SchoolLevel { get; set; }

}


public class StudentDto:BaseUserEntity
{
    public Guid UserId { get; set; }
    public Guid SchoolLevelId { get; set; }
    public UserDto User { get; set; }
    public SchoolClassLevelDto SchoolLevel { get; set; }
}
