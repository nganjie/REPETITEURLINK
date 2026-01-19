using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using REPETITEURLINK;
using REPETITEURLINK.Entities.Repositories;
using REPETITEURLINK.Extensions;
using REPETITEURLINK.Services;
using REPETITEURLINK.Services.Contracts;
using REPETITEURLINK.Services.Security;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppConfiguration>(builder.Configuration.GetSection("AppConfiguration"));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("AppConfiguration:JwtSettings"));
var config =builder.Configuration.GetSection("AppConfiguration").Get<AppConfiguration>();
if(config == null) {
    throw new Exception("AppConfiguration section not found in the appsettings.json");
}
ConnectionStringProvider.ConnectionString = config.Database.ConnectString;

builder.Services.AddDbContext<RepetitionLinkDataContext>(options =>
{
    options.UseNpgsql(config.Database.ConnectString, npgsqlOptions =>
    {
        npgsqlOptions.EnableRetryOnFailure(
            maxRetryCount: 3,
            maxRetryDelay: TimeSpan.FromSeconds(3),
            errorCodesToAdd: new[] {"40001"}
            );
    });
});

builder.Services.AddControllers().AddJsonOutputConfiguration();
builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = config.Swagger.Title,
        Version = config.Swagger.Version,
        Description = config.Swagger.Description
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //options.IncludeXmlComments(xmlPath);

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
});
builder.Services.AddOpenApi();

builder.Services.AddSingleton(x => config);
builder.Services.AddSingleton(x=>config.JwtSettings);
builder.Services.AddSingleton(x => config.DefaultSettings);
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddSingleton<CoreQueueService>();
builder.Services.AddScoped<IRepository,Repository>();
builder.Services.AddScoped<IDirectoryItemService, DirectoryItemService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

var app = builder.Build();
var lifeCycle = app.Lifetime;
lifeCycle.ApplicationStarted.Register(() =>
{
    Console.WriteLine("Application started");
    #region DATABASE migration regions
    using var scope = app.Services.CreateScope();
    using var dbCtx = scope.ServiceProvider.GetRequiredService<RepetitionLinkDataContext>();
    dbCtx.Database.CanConnect();
    dbCtx.Database.Migrate();
    Console.WriteLine("DB migration ended");
    #endregion
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
