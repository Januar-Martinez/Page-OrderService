using System.Text.Json.Serialization;

namespace OrderServiceApp.Models
{
    public class OrderStatistics
    {
        [JsonPropertyName("top_products")]
        public List<TopProduct> TopProducts { get; set; } = new();

        [JsonPropertyName("total_revenue")]
        public decimal TotalRevenue { get; set; }

        [JsonPropertyName("orders_by_customer")]
        public List<CustomerOrderStatistics> OrdersByCustomer { get; set; } = new();
    }
}
