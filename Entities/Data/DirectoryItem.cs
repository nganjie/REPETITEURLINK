using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class DirectoryItem:EntityBase
{
    public DirectoryKinds kind { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
    public string? Symbole { get; set; }
    public string? CountryId { get; set; }
    public string? CityId { get; set; }

    [ForeignKey(nameof(CountryId))]
    public DirectoryItem? Country { get; set; }
    [ForeignKey(nameof(CityId))]
    public DirectoryItem? City { get; set; }
}

public enum DirectoryKinds
{
    /// <summary>
    /// Cameroun,Congo , Gabon,....
    /// </summary>
    Country,
    /// <summary>
    /// XAF
    /// </summary>
    Currency,
    /// <summary>
    /// Douala,Yaounde,Bafoussam,....
    /// </summary>
    City,
    /// <summary>
    /// Makepe,Bonamoussadi,Bonaberi,....
    /// </summary>
    Neighborhood,
    /// <summary>
    /// Class Name Levels
    /// CP1, CP2, CE1, CE2, CM1, CM2, 6eme, 5eme, 4eme, 3eme, Seconde, Premiere, Terminale, L1, L2, L3, M1, M2
    /// </summary>
    SchoolClassLevel
}

class CountryDto
{
    public DirectoryKinds kind { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
    public string? Symbole { get; set; }
}
public class CurrencyDto
    {
    public DirectoryKinds kind { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
    public string Symbole { get; set; }
}
public class CityDto
{
    public DirectoryKinds kind { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
    public string? CountryId { get; set; }
    public DirectoryItem Country { get; set; }
}
public class NeighborhoodDto
{
    public DirectoryKinds kind { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
    public DirectoryItem City { get; set; }

}

public class SchoolClassLevelDto
{
    public DirectoryKinds kind { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
}

