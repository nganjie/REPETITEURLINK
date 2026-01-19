using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class SubjectRepetition:EntityBase
{
    public Guid LevelSubjectEncadreurId { get; set; }
    [ForeignKey(nameof(LevelSubjectEncadreurId))]
    public LevelSubjectEncadreur LevelSubjectEncadreur { get; set; }
    public Guid RepetitionId { get; set; }
    [ForeignKey(nameof(RepetitionId))]
    public Repetition Repetition { get; set; }
}

public class SubjectRepetitionDto:EntityBase
{
    public Guid LevelSubjectEncadreurId { get; set; }
    public LevelSubjectEncadreurDto LevelSubjectEncadreur { get; set; }
    public Guid RepetitionId { get; set; }
    public RepetitionDto Repetition { get; set; }
}