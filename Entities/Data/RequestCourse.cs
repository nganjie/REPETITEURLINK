using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class RequestCourse:EntityBase
{
    public Guid UserId { get; set; }
    public Guid EncadreurId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    [ForeignKey(nameof(EncadreurId))]
    public Encadreur Encadreur { get; set; }
    public StatusRequestEnum status { get; set; }
    public string message { get; set; }
    //public List<>
}

public enum StatusRequestEnum
{
    Created,
    Accepted,
    Deleted,
    Read,
    UnRead,
    Rejected,
}

public class RequestCourseDto:EntityBase
{
    public StatusRequestEnum status { get; set; }
    public string message { get; set; }
    public EncadreurDto Encadreur { get; set; }
    public UserDto User { get; set; }
    //public List<>
}