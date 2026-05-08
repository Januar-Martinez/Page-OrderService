using System.Text.Json.Serialization;

namespace OrderServiceApp.Models
{
    public class OrderRequest
    {
        [JsonPropertyName("customer_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("products")]
        public List<OrderItemRequest> Products { get; set; } = new();
    }

    public class OrderItemRequest
    {
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
