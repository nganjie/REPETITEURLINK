using REPETITEURLINK.Entities;
using REPETITEURLINK.Entities.Data;
using REPETITEURLINK.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace REPETITEURLINK.Services.Contracts;


public interface IDirectoryItemService
{
    Task<ApiResponse<DirectoryItemDto[]>> GetCountriesAsync(string search, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto[]>> GetCurrenciesAsync(string search, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto>> CreateDirectoryItemAsync(DirectoryItemModel model, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto[]>> GetSchoolLevelAsync(string search, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto[]>> GetCityAsync(string search, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto[]>> GetNeighborhoodAsync(string search, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto>> GetCountryByIdAsync(Guid countryId, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto>> GetCurrencyByIdAsync(Guid currencyId, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto>> GetSchoolLevelByIdAsync(Guid itemId, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto>> GetCityByIdAsync(Guid itemId, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto>> GetNeighborhoodByIdAsync(Guid itemId, CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryKinds[]>> GetDirectoryItemKindsAsync(CancellationToken cancellationToken);
    Task<ApiResponse<DirectoryItemDto[]>> GetAllItemsAsync(CancellationToken cancellationToken, DirectoryKinds? kind = null);
    Task<ApiResponse<DirectoryItemDto>> UpdateDirectoryItemAsync(DirectoryItemModel model, Guid directoryItemId, CancellationToken cancellationToken);
}

