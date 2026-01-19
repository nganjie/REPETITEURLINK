using REPETITEURLINK.Entities.Data;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace REPETITEURLINK.Services.Security;

public interface IJwtTokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}