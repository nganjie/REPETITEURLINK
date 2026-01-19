namespace REPETITEURLINK;

public class AppConfiguration
{
    public Database Database { get; set; }
    public Sentry Sentry { get; set; }
    public JwtSettings JwtSettings { get; set; }
    public SwaggerSetting Swagger { get; set; }
    public DefaultSettings DefaultSettings { get; set; }
}
public class Database
{
    public string ConnectString { get; set; }
}
public class Sentry
{
    public string Dsn { get; set; }
    public bool Debug { get; set; }
    public string Env { get; set; }
    public string Rate { get; set; }
}

/// <summary>
/// Configuration settings for JWT authentication
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Secret key for signing JWT tokens (minimum 32 characters)
    /// </summary>
    public string SecretKey { get; set; } = string.Empty;

    /// <summary>
    /// Token issuer (who creates the token)
    /// </summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>
    /// Token audience (who can use the token)
    /// </summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>
    /// Access token expiration time in minutes
    /// </summary>
    public int ExpirationInMinutes { get; set; } = 60;

    /// <summary>
    /// Refresh token expiration time in days
    /// </summary>
    public int RefreshTokenExpirationInDays { get; set; } = 7;
}
public class DefaultSettings
{
    public Guid CountryId { get; set; }
    public Guid CurrencyId { get; set; }
    public string CorsOrigins { get; set; }
    public bool AutoAssignCustomerManager { get; set; }
    public string AdminPassword { get; set; }
    public string AdminPhone { get; set; }
    public string AdminEmail { get; set; }
    public string CurrentClientAppVersion { get; set; }
}
public class SwaggerSetting
{
    public bool ShowSwagger { get; set; }
    public string Version { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string LicenseUrl { get; set; }
    public string Email { get; set; }
    public string TeamName { get; set; }
    public string TermsOfServiceUrl { get; set; }
}