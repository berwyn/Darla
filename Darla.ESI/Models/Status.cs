using System.Text.Json.Serialization;

namespace Darla.ESI.Models
{
    public class Status
    {
        [JsonPropertyName("players")]
        public int PlayerCount { get; set; }
        [JsonPropertyName("server_version")]
        public string ServerVersion { get; set; }
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }
        [JsonPropertyName("vip")]
        public bool IsVIPMode { get; set; }
    }
}
