namespace OrderServiceApp.Models
{
    public enum FieldType
    {
        Text,
        Number,
        Boolean,
        Hidden
    }

    public class ModalFieldConfig
    {
        public string Id { get; set; } = "";
        public string Label { get; set; } = "";
        public string? Icon { get; set; }
        public FieldType Type { get; set; } = FieldType.Text;
        public bool ShowOnlyWhenOperation { get; set; } = false;
        public bool ToUpperCase { get; set; } = false;
        public string TrueLabel { get; set; } = "Sí";
        public string FalseLabel { get; set; } = "No";
    }
}
