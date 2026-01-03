using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace REPETITEURLINK.Entities.Data;

    public class EntityBase
    {
    [JsonPropertyOrder(1)]
    [Key]
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyOrder(8)]
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyOrder(9)]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyOrder(10)]
    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }
    [JsonPropertyOrder(11)]
    [JsonPropertyName("deleted_on")]
    public DateTime? DeletedOn { get; set; }
}

