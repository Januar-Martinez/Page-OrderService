using System.Text.Json.Serialization;

namespace OrderServiceApp.Models
{
    public class CustomerOrderStatistics
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("email")]
        public string Email { get; set; } = "";

        [JsonPropertyName("total_orders")]
        public int TotalOrders { get; set; }

        [JsonPropertyName("total_spent")]
        public decimal? TotalSpent { get; set; }
    }
}
