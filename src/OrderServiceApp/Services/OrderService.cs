using OrderServiceApp.Models;

namespace OrderServiceApp.Services
{
    public class OrderService(HttpClient http)
    {
        public async Task<List<Order>> GetAllAsync()
        {
            return await http.GetFromJsonAsync<List<Order>>("orders") ?? new();
        }

        public async Task<ApiResponse<Order>> CreateAsync(OrderRequest request)
        {
            try
            {
                var response = await http.PostAsJsonAsync("orders", request);

                if (response.IsSuccessStatusCode)
                {
                    var created = await response.Content.ReadFromJsonAsync<Order>();

                    return new ApiResponse<Order>
                    {
                        Success = true,
                        StatusCode = (int)response.StatusCode,
                        Message = "Pedido registrado correctamente",
                        Data = created
                    };
                }

                var error = await response.Content.ReadFromJsonAsync<ApiError>();

                return new ApiResponse<Order>
                {
                    Success = false,
                    StatusCode = (int)response.StatusCode,
                    Message = error?.Error ?? "Error desconocido"
                };
            }
            catch
            {
                return new ApiResponse<Order>
                {
                    Success = false,
                    StatusCode = 500,
                    Message = "No fue posible conectar con el servidor"
                };
            }
        }

        public async Task<OrderStatistics?> GetStatisticsAsync()
        {
            try
            {
                return await http.GetFromJsonAsync<OrderStatistics>("orders/statistics");
            }
            catch
            {
                return null;
            }
        }
    }
}