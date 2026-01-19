using REPETITEURLINK.Services.JsonExtensions;
using System.Text.Json.Serialization;

namespace REPETITEURLINK.Extensions;

public static class MvcJsonExtensions
{
    public static IMvcBuilder AddJsonOutputConfiguration(this IMvcBuilder builder)
    {
        return builder.AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
            options.JsonSerializerOptions.DictionaryKeyPolicy = new SnakeCaseNamingPolicy();
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    }
}