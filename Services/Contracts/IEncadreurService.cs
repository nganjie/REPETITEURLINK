using REPETITEURLINK.Entities;
using REPETITEURLINK.Entities.Data;
using REPETITEURLINK.Entities.Models;
using REPETITEURLINK.Services.Security;

namespace REPETITEURLINK.Services.Contracts;

public interface IEncadreurService
{
    Task<ApiResponse<UserDto>> CreateUserAsync(
        CreateUserModel model,
        UserInfo currentUser,
        CancellationToken cancellationToken);

}
