using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace REPETITEURLINK.Services.Queues;

public class BaseRequestMessage
{
    [JsonPropertyName("update_type")]
    public required string UpdateType { get; set; }

    [JsonPropertyName("ts")]
    public required DateTime Ts { get; set; }

}

public class RequestMessage<T> : BaseRequestMessage
{
    [JsonPropertyName("data")]
    public required T Data { get; set; }
}

public class PushMessage : BaseRequestMessage
{
    [JsonPropertyName("data")]
    public object Data { get; set; }
    [JsonPropertyName("queue_name")]
    public string QueueName { get; set; }
}