namespace OrderServiceApp.Models
{
    public class NavItemConfig
    {
        public string Label { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string? Icon { get; set; }
    }

    public static class MenuConfig
    {
        public static List<NavItemConfig> Items => new()
        {
            new() { Label = "Inicio", Link = "/", Icon = "fa-solid fa-house" },
            new() { Label = "Clientes", Link = "/customers", Icon = "fa-solid fa-users" },
            new() { Label = "Productos", Link = "/products", Icon = "fa-solid fa-box-open" },
            new() { Label = "Pedidos", Link = "/orders", Icon = "fa-solid fa-cart-shopping" },
            new() { Label = "Estadísticas", Link = "/statistics", Icon = "fa-solid fa-chart-line" },
        };
    }
}
