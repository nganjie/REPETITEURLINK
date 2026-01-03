using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class SubjectEncadreur:EntityBase
{
    public string SubjectId { get; set; }
    public string EncadreurId { get; set; }

    [ForeignKey(nameof(SubjectId))]
    public Subject Subject { get; set; }
    [ForeignKey(nameof(EncadreurId))]
    public Encadreur Encadreur { get; set; }
}
