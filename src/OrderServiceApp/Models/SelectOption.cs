namespace OrderServiceApp.Models
{
    public class SelectOption
    {
        public string Value { get; set; } = "";
        public string Label { get; set; } = "";
    }

    public class ProductOption
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Price { get; set; }
    }
}
