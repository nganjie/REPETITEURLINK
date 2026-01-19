using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

namespace REPETITEURLINK.Entities.Data;

public class MessagePayload:EntityBase
{
    public string TextContent { get; set; }
    public string MediaUrl { get; set; }
    public string MediaType { get; set; }
    public decimal MediaSize { get; set; }
    public string _ExtraJson { get; set; }
    [NotMapped]
    public JSObject ExtraJson
    {
        get
        {
            return string.IsNullOrEmpty(_ExtraJson) ? null : JsonSerializer.Deserialize<JSObject>(_ExtraJson);
        }
    }
}

public class MessagePayloadDto:EntityBase
{
    public string TextContent { get; set; }
    public string MediaUrl { get; set; }
    public string MediaType { get; set; }
    public decimal MediaSize { get; set; }
    public string _ExtraJson { get; set; }
    [NotMapped]
    public JSObject ExtraJson
    {
        get
        {
            return string.IsNullOrEmpty(_ExtraJson) ? null : JsonSerializer.Deserialize<JSObject>(_ExtraJson);
        }
    }
}
