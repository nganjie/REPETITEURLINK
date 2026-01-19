using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class SessionRepetition:EntityBase
{
    public Guid RepetitionId { get; set; }
    [ForeignKey(nameof(RepetitionId))]
    public Repetition Repetition { get; set; }
    public Guid SubjectRepetitionId { get; set; }
    [ForeignKey(nameof(SubjectRepetitionId))]
    public SubjectRepetition SubjectRepetition { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
   
}

public class SessionRepetitionDto:EntityBase
{
    public RepetitionDto Repetition { get; set; }
    public Guid SubjectRepetitionId { get; set; }
    public SubjectRepetitionDto SubjectRepetition { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public Guid RepetitionId { get; set; }
    
}
