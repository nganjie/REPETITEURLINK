using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class DocumentCertification:Document
{
    public Guid VerificationCertificationId { get; set; }
    [ForeignKey(nameof(VerificationCertificationId))]
    public VerificationCertification VerificationCertification { get; set; }
}

public class DocumentCertificationDto: Document
{
    public Guid VerificationCertificationId { get; set; }
    public VerificationCertificationDto VerificationCertification { get; set; }
}