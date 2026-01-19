using Microsoft.EntityFrameworkCore;
using REPETITEURLINK.Services.Contracts;
using REPETITEURLINK.Services.Queues;
using REPETITEURLINK.Entities;
using REPETITEURLINK.Entities.Data;
using REPETITEURLINK.Entities.Extensions;
using REPETITEURLINK.Entities.Models;
using REPETITEURLINK.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace REPETITEURLINK.Services;

public class DirectoryItemService : BaseRepository, IDirectoryItemService
{
    private readonly CoreQueueService _mqMessages;
    public DirectoryItemService(IRepository repository, CoreQueueService mqMessages, AppConfiguration config) : base(repository, config)
    {
        _mqMessages = mqMessages;
    }


    public async Task<ApiResponse<DirectoryItemDto[]>> GetCountriesAsync(string search, CancellationToken cancellationToken)
    {
        var countries = await _repository.GetAll<DirectoryItem>()
             .Search(search)
             .OnlyCountries()
             .Select(x => x.ToDto())
             .ToArrayAsync();

        return ApiResponse<DirectoryItemDto[]>.Success(countries);

    }

    public async Task<ApiResponse<DirectoryItemDto[]>> GetAllItemsAsync(CancellationToken cancellationToken,DirectoryKinds? kind = null)
    {
        var data = await _repository.GetAll<DirectoryItem>()
            .FilterByKind(kind)
             .Select(x => x.ToDto())
             .ToArrayAsync();

        return ApiResponse<DirectoryItemDto[]>.Success(data);

    }


    public async Task<ApiResponse<DirectoryItemDto[]>> GetSchoolLevelAsync(string search, CancellationToken cancellationToken) {
        var data = await _repository.GetAll<DirectoryItem>()
             .Search(search)
             .OnlySchoolClassLevels()
             .Select(x => x.ToDto())
             .ToArrayAsync();

        return ApiResponse<DirectoryItemDto[]>.Success(data);
    }
    public async Task<ApiResponse<DirectoryItemDto[]>> GetCityAsync(string search, CancellationToken cancellationToken) {
        var data = await _repository.GetAll<DirectoryItem>()
             .Search(search)
             .OnlyCity()
             .Select(x => x.ToDto())
             .ToArrayAsync();

        return ApiResponse<DirectoryItemDto[]>.Success(data);
    }
    public async Task<ApiResponse<DirectoryItemDto[]>> GetNeighborhoodAsync(string search, CancellationToken cancellationToken) {
        var data = await _repository.GetAll<DirectoryItem>()
             .Search(search)
             .OnlyNeighborhood()
             .Select(x => x.ToDto())
             .ToArrayAsync();

        return ApiResponse<DirectoryItemDto[]>.Success(data);
    }

    public async Task<ApiResponse<DirectoryItemDto[]>> GetCurrenciesAsync(string search, CancellationToken cancellationToken)
    {
        var items = await _repository.GetAll<DirectoryItem>()
            .Search(search)
            .OnlyCurrencies()
            .Select(x => x.ToDto())
            .ToArrayAsync();

        return ApiResponse<DirectoryItemDto[]>.Success(items);

    }

    public async Task<ApiResponse<DirectoryItemDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var item = await _repository.GetAll<DirectoryItem>()
            .Where(x => x.Id == id)
            .Select(x => x.ToDto())
            .FirstOrDefaultAsync();
        return ApiResponse<DirectoryItemDto>.Success(item);

    }

    public async Task<ApiResponse<DirectoryItemDto>> CreateDirectoryItemAsync(DirectoryItemModel model, CancellationToken cancellationToken)
    {

        var exist = await _repository.GetAll<DirectoryItem>()
            .Search(model.DisplayName)
            .AnyAsync();

        if (exist)
        {
            return ApiResponse<DirectoryItemDto>.Failure("record with this display name exist");

        }


        var item = new DirectoryItem
        {
            CreatedAt = DateTime.UtcNow,
            DisplayName = model.DisplayName,
            Kind = model.Kind,
            Value = model.Value,
            IsDeleted = false,
            Symbol = model.Symbol,
        };
        await _repository.InsertAsync(item);
        _mqMessages.EnqueueMessage(new PushMessage
        {
            Data = new RequestMessage<DirectoryItem>
            {
                Data = item,
                UpdateType = nameof(QueueSubjectTypes.DirectoryItem),
                Ts = DateTime.UtcNow
            },
            QueueName = "updates",
            UpdateType = nameof(QueueSubjectTypes.DirectoryItem),
            Ts = DateTime.UtcNow
        });

        return ApiResponse<DirectoryItemDto>.Success(item.ToDto());


    }

    public async Task<ApiResponse<DirectoryItemDto>> UpdateDirectoryItemAsync(DirectoryItemModel model, Guid directoryItemId, CancellationToken cancellationToken)
    {

        var item = await _repository.GetAll<DirectoryItem>()
            .Where(x => x.Id == directoryItemId)
            .FirstOrDefaultAsync();

        if (item == null)
        {
            return ApiResponse<DirectoryItemDto>.Failure("record with not found");

        }


        item.DisplayName = model.DisplayName;
        item.Kind = model.Kind;
        item.Value = model.Value;
        item.Symbol = model.Symbol;
        item.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(item);
        _mqMessages.EnqueueMessage(new PushMessage
        {
            Data = new RequestMessage<DirectoryItem>
            {
                Data = item,
                UpdateType = nameof(QueueSubjectTypes.DirectoryItem),
                Ts = DateTime.UtcNow
            },
            QueueName = "updates",
            UpdateType = nameof(QueueSubjectTypes.DirectoryItem),
            Ts = DateTime.UtcNow
        });

        return ApiResponse<DirectoryItemDto>.Success(item.ToDto());


    }




    public async Task<ApiResponse<DirectoryItemDto>> GetCountryByIdAsync(Guid countryId, CancellationToken cancellationToken)
    {
        var item = await _repository.GetAll<DirectoryItem>()
            .Where(x => x.Id == countryId && x.Kind == DirectoryKinds.Country).Select(x => x.ToDto())
            .FirstOrDefaultAsync(); ;
        return ApiResponse<DirectoryItemDto>.Success(item);
    }
    public async Task<ApiResponse<DirectoryItemDto>> GetSchoolLevelByIdAsync(Guid itemId, CancellationToken cancellationToken)
    {
        var item = await _repository.GetAll<DirectoryItem>()
            .Where(x => x.Id == itemId && x.Kind == DirectoryKinds.SchoolClassLevel).Select(x => x.ToDto())
            .FirstOrDefaultAsync(); ;
        return ApiResponse<DirectoryItemDto>.Success(item);
    }
    public async Task<ApiResponse<DirectoryItemDto?>> GetCityByIdAsync(Guid itemId, CancellationToken cancellationToken)
    {
        var item = await _repository.GetAll<DirectoryItem>()
            .Where(x => x.Id == itemId && x.Kind == DirectoryKinds.City).Select(x => x.ToDto())
            .FirstOrDefaultAsync(); ;
        return ApiResponse<DirectoryItemDto>.Success(item);
    }
    public async Task<ApiResponse<DirectoryItemDto>> GetNeighborhoodByIdAsync(Guid itemId, CancellationToken cancellationToken)
    {
        var item = await _repository.GetAll<DirectoryItem>()
            .Where(x => x.Id == itemId && x.Kind == DirectoryKinds.Neighborhood).Select(x => x.ToDto())
            .FirstOrDefaultAsync(); ;
        return ApiResponse<DirectoryItemDto>.Success(item);
    }

    public async Task<ApiResponse<DirectoryItemDto>> GetCurrencyByIdAsync(Guid currencyId, CancellationToken cancellationToken)
    {
        var item = await _repository.GetAll<DirectoryItem>()
             .Where(x => x.Id == currencyId && x.Kind == DirectoryKinds.SchoolClassLevel).Select(x => x.ToDto())
             .FirstOrDefaultAsync(); ;
        return ApiResponse<DirectoryItemDto>.Success(item);
    }

    public async Task<ApiResponse<DirectoryKinds[]>> GetDirectoryItemKindsAsync(CancellationToken cancellationToken)
    {
        var items = await _repository.GetAll<DirectoryItem>()
            .Select(x => x.Kind)
            .Distinct()
            .ToArrayAsync();

        return ApiResponse<DirectoryKinds[]>.Success(items);


    }
}
