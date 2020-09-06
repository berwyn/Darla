using System.Text.Json.Serialization;

namespace Darla.ESI.Models
{
    public class RateLimitResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }

    public class BadRequestResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }

    public class InternalServerErrorResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }

    public class ServiceUnavailableResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }

    public class GatewayTimeoutResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }
        [JsonPropertyName("timeout")]
        public int Timeout { get; set; }
    }
}
