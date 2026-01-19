using NeinLinq;
using REPETITEURLINK.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace REPETITEURLINK.Entities.Extensions;

public static class DirectoryItemExtension
{
    #region DirectoryItemDto
   
    private static Func<DirectoryItem, DirectoryItemDto> _model;
    private static Expression<Func<DirectoryItem, DirectoryItemDto>> ToDto()
        => entity => new DirectoryItemDto
        {
            DisplayName = entity.DisplayName,
            Id = entity.Id,
            Kind = entity.Kind,
            Symbol = entity.Symbol,
            Value = entity.Value,
            IsNative= entity.IsNative,
            IsDeleted= entity.IsDeleted,
        };
    [InjectLambda]
    public static DirectoryItemDto ToDto(this DirectoryItem entity)
        => (_model ??= ToDto().Compile()).Invoke(entity);

    #endregion
    
    #region City  
    private static Func<DirectoryItem, CityDto> _city;
    private static Expression<Func<DirectoryItem, CityDto>> ToCityDto()
        => entity => new CityDto
        {
            Id = entity.Id,
            CountryId=entity.CountryId,
            DisplayName = entity.DisplayName,
            Country=entity.Country.ToDto(),
            Value=entity.Value,
            IsNative = entity.IsNative,
            IsDeleted = entity.IsDeleted,
        };
    [InjectLambda]
    public static CityDto ToCityDto(this DirectoryItem entity)
        => (_city ??= ToCityDto().Compile()).Invoke(entity);

    #endregion
    #region Neighborhood
   
    private static Func<DirectoryItem, NeighborhoodDto> _neighborhood;
    private static Expression<Func<DirectoryItem, NeighborhoodDto>> ToNeighborhoodDto()
        => entity => new NeighborhoodDto
        {
            
            Id = entity.Id,
            Kind= entity.Kind,
            Value=entity.Value,
            DisplayName = entity.DisplayName,
            City=entity.City.ToCityDto(),
            IsNative=entity.IsNative,
            IsDeleted=entity.IsDeleted,


        };
    [InjectLambda]
    public static NeighborhoodDto ToNeighborhoodDto(this DirectoryItem entity)
        => (_neighborhood ??= ToNeighborhoodDto().Compile()).Invoke(entity);

    public static Func<DirectoryItem, CountryDto> _country;

    private static Expression<Func<DirectoryItem, CountryDto>> ToCountryDto()
        => entity => new CountryDto
        {
            Id = entity.Id,
            Kind = entity.Kind,
            Symbol = entity.Symbol,
            Value = entity.Value,
            DisplayName = entity.DisplayName,
            IsNative = entity.IsNative,
            IsDeleted = entity.IsDeleted,

        };
    [InjectLambda]
    public static CountryDto ToCountryDto(this DirectoryItem entity)
        =>(_country??=ToCountryDto().Compile()).Invoke(entity);

    #endregion
    #region SchoolLevel
    private static Func<DirectoryItem,SchoolClassLevelDto> _schoolClassLevel;
    private static Expression<Func<DirectoryItem, SchoolClassLevelDto>> ToSchoolLevel()
        => entity => new SchoolClassLevelDto {
            Id = entity.Id,
            Kind = entity.Kind,
            Value = entity.Value,
            DisplayName = entity.DisplayName,
            IsNative = entity.IsNative,
            IsDeleted = entity.IsDeleted,
        };
    [InjectLambda]
    public static SchoolClassLevelDto ToSchoolLevel(this DirectoryItem entity)
        => (_schoolClassLevel ??= ToSchoolLevel().Compile()).Invoke(entity);
    #endregion

    public static IQueryable<DirectoryItem> Search(this IQueryable<DirectoryItem> query, string? search)
    {
        if (!string.IsNullOrEmpty(search))
        {
            var loweredSearch = search.ToLower();
            return query.Where(x => (x.DisplayName.ToLower() == loweredSearch || x.Value.ToLower() == loweredSearch || x.Symbol == loweredSearch));

        }
        return query;
    }
    public static IQueryable<DirectoryItem> OnlyCountries(this IQueryable<DirectoryItem> query)
        => query.Where(x => x.Kind == DirectoryKinds.Country);
    public static IQueryable<DirectoryItem> OnlyCurrencies(this IQueryable<DirectoryItem> query)
           => query.Where(x => x.Kind == DirectoryKinds.Currency);

    public static IQueryable<DirectoryItem> OnlySchoolClassLevels(this IQueryable<DirectoryItem> query)
         => query.Where(x => x.Kind == DirectoryKinds.SchoolClassLevel);
    public static IQueryable<DirectoryItem> OnlyCity(this IQueryable<DirectoryItem> query)
        => query.Where(x => x.Kind == DirectoryKinds.City);
   public static IQueryable<DirectoryItem> OnlyNeighborhood(this IQueryable<DirectoryItem> query)
        =>query.Where(x=>x.Kind == DirectoryKinds.Neighborhood);
    public static IQueryable<DirectoryItem> FilterByKind(this IQueryable<DirectoryItem> query, DirectoryKinds? Kind)
        => Kind == null ? query : query.Where(x => x.Kind == Kind);
}
