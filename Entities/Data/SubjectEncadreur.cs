using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

//public class SubjectEncadreur:EntityBase
//{
//    public Guid SubjectId { get; set; }
//    public Guid EncadreurId { get; set; }
//    public decimal HourlyRate { get; set; }

//    [ForeignKey(nameof(SubjectId))]
//    public Subject Subject { get; set; }
//    [ForeignKey(nameof(EncadreurId))]
//    public Encadreur Encadreur { get; set; }
//    List<LevelSubjectEncadreur> LevelSubjectEncadreurs { get; set; }= new List<LevelSubjectEncadreur>();
//}

//public class SubjectEncadreurDto:EntityBase
//{
//    public Guid SubjectId { get; set; }
//    public Guid EncadreurId { get; set; }
//    public decimal HourlyRate { get; set; }
//    public SubjectDto Subject { get; set; }
//    public EncadreurDto Encadreur { get; set; }
//    List<LevelSubjectEncadreur> LevelSubjectEncadreurs { get; set; }= new List<LevelSubjectEncadreur>();
//}