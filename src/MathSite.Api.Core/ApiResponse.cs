using Newtonsoft.Json;

namespace MathSite.Api.Core
{
    public sealed class ErrorApiResponse<T> : ApiResponse<T>
    {
        public ErrorApiResponse(string reason, string details = null) : base(default)
        {
            Status = ApiStatuses.Error;
            Reason = reason;
            Details = details;
        }
    }

    public sealed class VoidApiResponse<T> : ApiResponse<T>
    {
        public VoidApiResponse() : base(default)
        {
            Status = ApiStatuses.Ok;
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public ApiResponse(T data)
        {
            Status = ApiStatuses.Ok;
            Data = data;
        }

        [JsonProperty("data", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public T Data { get; set; }
    }

    public abstract class ApiResponse
    {
        [JsonProperty("status")]
        public string Status { get; protected set; }
        
        [JsonProperty("reason", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Reason { get; protected set; }
        
        [JsonProperty("details", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Details { get; protected set; }

        public bool HasError()
        {
            return !string.IsNullOrWhiteSpace(Status) && Status.ToLowerInvariant() == ApiStatuses.Error;
        }
    }
}