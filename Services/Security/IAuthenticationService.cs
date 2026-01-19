using REPETITEURLINK.Entities;
using REPETITEURLINK.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace REPETITEURLINK.Services.Security;

public interface IAuthenticationService
{
    Task<ApiResponse<LoginResponse?>> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
    Task<ApiResponse<LoginResponse?>> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken);
    Task<ApiResponse<bool>> ChangePasswordAsync(Guid userId, ChangePasswordRequest request, CancellationToken cancellationToken);
    Task<ApiResponse<bool>> LogoutAsync(Guid userId, CancellationToken cancellationToken);
    Task<ApiResponse<UserDto>> RegisterUserAsync(RegisterUserRequest request, CancellationToken cancellationToken);
}