using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REPETITEURLINK.Entities.Data;

public class DirectoryItem:EntityBase
{
    public DirectoryKinds Kind { get; set; }
    public string Value { get; set; }
    [MaxLength(100)]
    public string DisplayName { get; set; }
    public string? Symbol { get; set; }
    public Guid? CountryId { get; set; }
    public Guid? CityId { get; set; }
    public bool IsNative { get; set; } = true;
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

public class DirectoryItemDto : EntityBase
{
    public DirectoryKinds Kind { get; set; }
    public string Value { get; set; }

    public string DisplayName { get; set; }
    public string? Symbol { get; set; }
    public Guid? CountryId { get; set; }
    public Guid? CityId { get; set; }
    public bool IsNative { get; set; } = true;
    public DirectoryItemDto? Country { get; set; }
    public DirectoryItemDto? City { get; set; }
}
public class CountryDto:EntityBase
{
    public DirectoryKinds Kind { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
    public string? Symbol { get; set; }
    public bool IsNative { get; set; } = true;
}
public class CurrencyDto : EntityBase
{
    public DirectoryKinds Kind { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
    public string Symbol { get; set; }
    public bool IsNative { get; set; } = true;
}
public class CityDto : EntityBase
{
    public DirectoryKinds Kind { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
    public Guid? CountryId { get; set; }
    public DirectoryItemDto Country { get; set; }
    public bool IsNative { get; set; } = true;
}
public class NeighborhoodDto : EntityBase
{
    public DirectoryKinds Kind { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
    public CityDto City { get; set; }
    public bool IsNative { get; set; } = true;

}

public class SchoolClassLevelDto : EntityBase
{
    public DirectoryKinds Kind { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
    public bool IsNative { get; set; } = true;
}

