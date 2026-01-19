using REPETITEURLINK.Entities.Data;

public class VerificationCertification : EntityBase
{
    public bool IsVerified { get; set; }
    public string? Comment { get; set; }
    public VericationStates Status { get; set; }
    public CertificationTypes CertificationType { get; set; }

}

public enum VericationStates
{
    Pending,
    Approved,
    Rejected
}
public enum CertificationTypes
{
    IdentityProof,
    AcademicDegree,
    ProfessionalCertification
}

public class VerificationCertificationDto : EntityBase
{
    public bool IsVerified { get; set; }
    public string? Comment { get; set; }
    public VericationStates Status { get; set; }
    public CertificationTypes CertificationType { get; set; }
}