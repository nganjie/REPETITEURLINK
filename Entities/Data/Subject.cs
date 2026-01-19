using System.ComponentModel.DataAnnotations;

namespace REPETITEURLINK.Entities.Data;

public class Subject:EntityBase
{
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string DisplayName { get; set; }
    public decimal AverageHourlyRate { get; set; }
}

public class SubjectDto:EntityBase
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public decimal AverageHourlyRate { get; set; }
}
