using OrderServiceApp.Models;

namespace OrderServiceApp.Services
{
    public class CustomerService(HttpClient http)
    {
        public async Task<List<Customer>> GetAllAsync()
        {
            return await http.GetFromJsonAsync<List<Customer>>("customers") ?? new();
        }

        public async Task<ApiResponse<Customer>> CreateAsync(Customer customer)
        {
            try
            {
                var response = await http.PostAsJsonAsync("customers", customer);

                if (response.IsSuccessStatusCode)
                {
                    var createdCustomer =
                        await response.Content.ReadFromJsonAsync<Customer>();

                    return new ApiResponse<Customer>
                    {
                        Success = true,
                        StatusCode = (int)response.StatusCode,
                        Message = "Cliente registrado correctamente",
                        Data = createdCustomer
                    };
                }

                var error =
                    await response.Content.ReadFromJsonAsync<ApiError>();

                return new ApiResponse<Customer>
                {
                    Success = false,
                    StatusCode = (int)response.StatusCode,
                    Message = error?.Error ?? "Error desconocido"
                };
            }
            catch
            {
                return new ApiResponse<Customer>
                {
                    Success = false,
                    StatusCode = 500,
                    Message = "No fue posible conectar con el servidor"
                };
            }
        }
    }
}