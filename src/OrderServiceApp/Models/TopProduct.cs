using System.Text.Json.Serialization;

namespace OrderServiceApp.Models
{
    public class TopProduct
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("total_sold")]
        public int TotalSold { get; set; }
    }
}
