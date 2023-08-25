using System.Text.Json.Serialization;

namespace BuisnessLogicLayer.Common
{
    public class Result<TData>
    {
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; init; }

        public bool IsSucceeded => (int)StatusCode >= 200 && (int)StatusCode <= 299;
        public string Message { get; init; }
        public TData Payload { get; init; }
    }
}
