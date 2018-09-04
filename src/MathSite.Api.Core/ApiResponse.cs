using Newtonsoft.Json;

namespace MathSite.Api.Core
{
    public sealed class DataApiResponse<T> : ApiResponse
    {
        [JsonProperty("data")] 
        public T Data { get; set; }

        public DataApiResponse(T data)
        {
            Status = ApiStatuses.Ok;
            Data = data;
        }
    }

    public sealed class ErrorApiResponse : ApiResponse
    {
        public ErrorApiResponse(string reason)
        {
            Status = ApiStatuses.Error;
            Reason = reason;
        }
    }

    public sealed class VoidApiResponse : ApiResponse
    {
        public VoidApiResponse()
        {
            Status = ApiStatuses.Ok;
        }
    }

    public abstract class ApiResponse
    {
        [JsonProperty("status")] 
        public string Status { get; protected set; }
        
        [JsonProperty("reason")] 
        public string Reason { get; protected set; }

        public bool HasError()
        {
            return !string.IsNullOrWhiteSpace(Status) && Status.ToLowerInvariant() == "error";
        }
    }
}