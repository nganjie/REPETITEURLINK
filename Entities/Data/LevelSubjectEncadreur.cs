using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class LevelSubjectEncadreur : EntityBase
{
    public Guid SubjectId { get; set; }
    public Guid EncadreurId { get; set; }
    public Guid SchoolLevelId { get; set; }
    public decimal HourlyRate { get; set; }
    [ForeignKey(nameof(SubjectId))]
    public Subject Subject { get; set; }
    [ForeignKey(nameof(SchoolLevelId))]
    public DirectoryItem SchoolLevel { get; set; }
    [ForeignKey(nameof(EncadreurId))]
    public Encadreur Encadreur { get; set; }
}

public class LevelSubjectEncadreurDto : EntityBase
{
    public Guid SubjectId { get; set; }
    public Guid EncadreurId { get; set; }
    public Guid SchoolLevelId { get; set; }
    public decimal HourlyRate { get; set; }
    public SubjectDto Subject { get; set; }
    public SchoolClassLevelDto SchoolLevel { get; set; }
    public EncadreurDto Encadreur { get; set; }
}
