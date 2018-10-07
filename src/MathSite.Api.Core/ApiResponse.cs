using Newtonsoft.Json;

namespace MathSite.Api.Core
{
    public sealed class ErrorApiResponse<T> : ApiResponse<T>
    {
        public ErrorApiResponse(string reason) : base(default)
        {
            Status = ApiStatuses.Error;
            Reason = reason;
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

        [JsonProperty("data")]
        public T Data { get; set; }
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