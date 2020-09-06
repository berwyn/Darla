using System.Text.Json.Serialization;

namespace Darla.ESI.Models
{
    public class ItemPrice
    {
        [JsonPropertyName("adjusted_price")]
        public double AdjustedPrice { get; set; }
        [JsonPropertyName("average_price")]
        public double AveragePrice { get; set; }
        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }
    }
}
