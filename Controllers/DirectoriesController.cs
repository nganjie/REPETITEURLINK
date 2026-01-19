using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using REPETITEURLINK.Services.Contracts;
using REPETITEURLINK.Entities;
using REPETITEURLINK.Entities.Data;
using REPETITEURLINK.Entities.Models;
using REPETITEURLINK.Entities.Repositories;

namespace REPETITEURLINK.Controllers;


[Route("api/directories")]
[ApiController]
public class DirectoriesController : BaseController
{
    private IDirectoryItemService _directoryService;
    public DirectoriesController(IDirectoryItemService directoryItemService, IHttpContextAccessor accessor, AppConfiguration config,IRepository repository) : base(accessor, config,repository)
    {
        _directoryService = directoryItemService;
    }

    /// <summary>
    /// get the list of available countries
    /// </summary>
    /// <param name="search"> the search expression</param>

    /// <returns></returns>
    [HttpGet]
    [ActionName("countries")]
    [Route("[action]")]
    public async Task<ApiResponse<DirectoryItemDto[]>> GetCountriesAsync(CancellationToken cancellationToken, string search = "")
    {
        var response = await _directoryService.GetCountriesAsync(search, cancellationToken);
        return response;
    }
    /// <summary>
    /// get the list of available cities
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="search"></param>
    /// <returns></returns>
    [HttpGet]
    [ActionName("cities")]
    [Route("[action]")]
    public async Task<ApiResponse<DirectoryItemDto[]>> GetCityAsync(CancellationToken cancellationToken, string search = "")
    {
        var response = await _directoryService.GetCityAsync(search, cancellationToken);
        return response;
    }
    /// <summary>
    /// get the list of available neighborhood
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="search"></param>
    /// <returns></returns>
    [HttpGet]
    [ActionName("neighborhood")]
    [Route("[action]")]
    public async Task<ApiResponse<DirectoryItemDto[]>> GetNeighborhoodAsync(CancellationToken cancellationToken, string search = "")
    {
        var response = await _directoryService.GetNeighborhoodAsync(search, cancellationToken);
        return response;
    }
    /// <summary>
    /// get the list of available schoolLevel
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="search"></param>
    /// <returns></returns>
    [HttpGet]
    [ActionName("school-level")]
    [Route("[action]")]
    public async Task<ApiResponse<DirectoryItemDto[]>> GetSchoolLevelAsync(CancellationToken cancellationToken, string search = "")
    {
        var response = await _directoryService.GetSchoolLevelAsync(search, cancellationToken);
        return response;
    }

    /// <summary>
    /// Get by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [ActionName("details")]
    [Route("{id:guid}/[action]")]
    public async Task<ApiResponse<DirectoryItemDto>> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        => await _directoryService.GetByIdAsync(id, cancellationToken);
    /// <summary>
    ///  Get city by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ActionName("city-details")]
    [Route("{id:guid}/[action]")]
    public async Task<ApiResponse<DirectoryItemDto>> GetCityDetailsAsync(Guid id, CancellationToken cancellationToken)
        => await _directoryService.GetCityByIdAsync(id, cancellationToken);

    /// <summary>
    ///  Get Neighborhood by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ActionName("neighborhood-details")]
    [Route("{id:guid}/[action]")]
    public async Task<ApiResponse<DirectoryItemDto>> GetNeighborhoodDetailsAsync(Guid id, CancellationToken cancellationToken)
        => await _directoryService.GetNeighborhoodByIdAsync(id, cancellationToken);
    /// <summary>
    ///  Get school-level by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ActionName("school-level-details")]
    [Route("{id:guid}/[action]")]
    public async Task<ApiResponse<DirectoryItemDto>> GetSchoolLevelDetailsAsync(Guid id, CancellationToken cancellationToken)
        => await _directoryService.GetNeighborhoodByIdAsync(id, cancellationToken);


    /// <summary>
    /// Get the list of currencies
    /// </summary>
    /// <param name="search">the search expression </param>
    /// <returns></returns>
    [HttpGet]
    [ActionName("currencies")]
    [Route("[action]")]
    public async Task<ApiResponse<DirectoryItemDto[]>> GetCurrenciesAsync(CancellationToken cancellationToken, string search = "")
        => await _directoryService.GetCurrenciesAsync(search, cancellationToken);

   /// <summary>
   /// Get items filtered by kind
   /// </summary>
   /// <param name="cancellationToken"></param>
   /// <param name="kinds"></param>
   /// <returns></returns>
    [HttpGet]
    [ActionName("items")]
    [Route("[action]")]
    public async Task<ApiResponse<DirectoryItemDto[]>> GetItemsAsync(CancellationToken cancellationToken, DirectoryKinds? kinds=null)
        => await _directoryService.GetAllItemsAsync(cancellationToken, kinds);

    /// <summary>
    /// Create new directory item
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [ActionName("create")]
    [Route("[action]")]
    public async Task<ApiResponse<DirectoryItemDto>> CreateDirectoryItem([FromBody] DirectoryItemModel model, CancellationToken cancellationToken)
    => await _directoryService.CreateDirectoryItemAsync(model, cancellationToken);



    /// <summary>
    /// Get Directory Item Kinds
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ActionName("kinds")]
    [Route("[action]")]
    public async Task<ApiResponse<DirectoryKinds[]>> GetDirectoryItemKindsAsync(CancellationToken cancellationToken)
        => await _directoryService.GetDirectoryItemKindsAsync(cancellationToken);

    /// <summary>
    /// Update Directory Item
    /// </summary>
    /// <param name="model"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut]
    [ActionName("update")]
    [Route("{id:guid}/[action]")]
    public async Task<ApiResponse<DirectoryItemDto>> UpdateDirectoryItemAsync([FromBody] DirectoryItemModel model, Guid id, CancellationToken cancellationToken)
        => await _directoryService.UpdateDirectoryItemAsync(model, id, cancellationToken);
}