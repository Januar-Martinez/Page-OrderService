using OrderServiceApp.Models;

namespace OrderServiceApp.Services
{
    public class ProductService(HttpClient http)
    {
        public async Task<List<Product>> GetAllAsync()
        {
            return await http.GetFromJsonAsync<List<Product>>("products") ?? new();
        }

        public async Task<ApiResponse<Product>> CreateAsync(Product product)
        {
            try
            {
                var response = await http.PostAsJsonAsync("products", product);

                if (response.IsSuccessStatusCode)
                {
                    var createdProduct =
                        await response.Content.ReadFromJsonAsync<Product>();

                    return new ApiResponse<Product>
                    {
                        Success = true,
                        StatusCode = (int)response.StatusCode,
                        Message = "Producto registrado correctamente",
                        Data = createdProduct
                    };
                }

                var error =
                    await response.Content.ReadFromJsonAsync<ApiError>();

                return new ApiResponse<Product>
                {
                    Success = false,
                    StatusCode = (int)response.StatusCode,
                    Message = error?.Error ?? "Error desconocido"
                };
            }
            catch
            {
                return new ApiResponse<Product>
                {
                    Success = false,
                    StatusCode = 500,
                    Message = "No fue posible conectar con el servidor"
                };
            }
        }

        public async Task<ApiResponse<Product>> UpdateAsync(Product product)
        {
            try
            {
                var response = await http.PutAsJsonAsync($"products/{product.Id}", product);

                if (response.IsSuccessStatusCode)
                {
                    var updatedProduct = await response.Content.ReadFromJsonAsync<Product>();

                    return new ApiResponse<Product>
                    {
                        Success = true,
                        StatusCode = (int)response.StatusCode,
                        Message = "Producto actualizado correctamente",
                        Data = updatedProduct
                    };
                }

                var error = await response.Content.ReadFromJsonAsync<ApiError>();

                return new ApiResponse<Product>
                {
                    Success = false,
                    StatusCode = (int)response.StatusCode,
                    Message = error?.Error ?? "Error desconocido"
                };
            }
            catch
            {
                return new ApiResponse<Product>
                {
                    Success = false,
                    StatusCode = 500,
                    Message = "No fue posible conectar con el servidor"
                };
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                var response = await http.DeleteAsync($"products/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return new ApiResponse<bool>
                    {
                        Success = true,
                        StatusCode = (int)response.StatusCode,
                        Message = "Producto eliminado correctamente",
                        Data = true
                    };
                }

                var error = await response.Content.ReadFromJsonAsync<ApiError>();

                return new ApiResponse<bool>
                {
                    Success = false,
                    StatusCode = (int)response.StatusCode,
                    Message = error?.Error ?? "Error desconocido",
                    Data = false
                };
            }
            catch
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    StatusCode = 500,
                    Message = "No fue posible conectar con el servidor",
                    Data = false
                };
            }
        }
    }
}
