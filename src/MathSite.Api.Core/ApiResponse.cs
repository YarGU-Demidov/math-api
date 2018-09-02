using Newtonsoft.Json;

namespace MathSite.Api.Core
{
    public sealed class ApiResponse<T> : ApiResponse
    {
        [JsonProperty("data")] 
        public T Data { get; set; }
    }

    public sealed class VoidApiResponse : ApiResponse
    {
    }

    public abstract class ApiResponse
    {
        [JsonProperty("status")] 
        public string Status { get; set; } = "ok";

        [JsonProperty("reason")] 
        public string Reason { get; set; }

        public bool HasError()
        {
            return !string.IsNullOrWhiteSpace(Status);
        }
    }
}