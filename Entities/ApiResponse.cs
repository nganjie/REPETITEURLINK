using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace REPETITEURLINK.Entities;

public class ApiResponse
{
    [JsonPropertyName("success")]
    public bool IsSuccess { get; set; } = false;
    [JsonPropertyName("error_code")]
    public int? ErrorCode { get; set; }
    [JsonPropertyName("error")]
    public string? ErrorMessage { get; set; }
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
public class ApiResponse<T> : ApiResponse
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }

    private ApiResponse(bool isSuccess, T? value, string? errorMessage, int? errorCode, string? message)
    {
        this.IsSuccess = isSuccess;
        this.Data = value;
        this.ErrorMessage = errorMessage;
        this.ErrorCode = errorCode;
        this.Message = message;
    }

    public static ApiResponse<T> Success(T value, string? message = null) => new(true, value, null, null, message);
    public static ApiResponse<T> Failure(string errorMessage, int errorCode = 422, string? message = null) => new(false, default, errorMessage, errorCode, message);

}

public class PaginatedResponse<T>
{
    /// <summary>
    /// Array of T elements
    /// </summary>
    [JsonPropertyOrder(1)]
    [JsonPropertyName("data")]
    public T[]? Data { get; set; }

    /// <summary>
    /// the pagination meta information
    /// </summary>
    [JsonPropertyOrder(0)]
    [JsonPropertyName("meta")]
    public PageMeta? Meta { get; set; }

}
public class PageMeta
{

    [JsonPropertyName("offset")]
    public int Offset { get; set; }
    [JsonPropertyName("limit")]
    public int Limit { get; set; }
    [JsonPropertyName("total")]
    public int Total { get; set; }

}
public class LookupDto
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; }
}

public class LookupDetailsDto : LookupDto
{
    public string Description { get; set; }
}
