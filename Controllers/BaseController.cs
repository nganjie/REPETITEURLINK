using Microsoft.AspNetCore.Mvc;
using REPETITEURLINK.Services.Security;
using REPETITEURLINK.Entities;
using REPETITEURLINK.Entities.Data;
using System.Security.Claims;
using System.Text.Json;
using REPETITEURLINK.Entities.Repositories;

namespace REPETITEURLINK.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : BaseSharedController
{
    protected readonly AppConfiguration _config;
    private readonly IRepository _repository;
    //protected readonly ApiResponse<UserDto>? _response;
    //protected readonly Guid? _currentOrganizationId;
    public BaseController(IHttpContextAccessor accessor, AppConfiguration config,IRepository repository) : base(accessor,repository)
    {
        _config = config;
        _repository=repository;
    }
}
