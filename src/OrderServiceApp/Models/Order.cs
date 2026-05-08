using System.Text.Json.Serialization;

namespace OrderServiceApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; } = "";

        [JsonPropertyName("customer_email")]
        public string CustomerEmail { get; set; } = "";
    }
}
