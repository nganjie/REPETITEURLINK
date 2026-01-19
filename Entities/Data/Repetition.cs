using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class Repetition:EntityBase
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid EncadreurId { get; set; }
    public Guid StudentId { get; set; }
    public Guid RequestCourseId { get; set; }
    [ForeignKey(nameof(EncadreurId))]
    public Encadreur Encadreur { get; set; }
    [ForeignKey(nameof(StudentId))]
    public Student Student { get; set; }
    [ForeignKey(nameof(RequestCourseId))]
    public RequestCourse RequestCourse { get; set; }
    public List<DayOfWeek> DayOfWeeks { get; set; } = new List<DayOfWeek>();
}
public enum DayOfWeek
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

public class RepetitionDto:EntityBase
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid EncadreurId { get; set; }
    public Guid StudentId { get; set; }
    public Guid RequestCourseId { get; set; }
    public EncadreurDto Encadreur { get; set; }
    public StudentDto Student { get; set; }
    public RequestCourseDto RequestCourse { get; set; }
    public List<DayOfWeek> DayOfWeeks { get; set; } = new List<DayOfWeek>();
}