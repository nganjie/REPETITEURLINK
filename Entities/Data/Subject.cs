namespace REPETITEURLINK.Entities.Data;

public class Subject:EntityBase
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public List<SubjectEncadreur> Encadreurs { get; set; }
}
