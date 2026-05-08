using Microsoft.AspNetCore.Components;

namespace OrderServiceApp.Models
{
    public enum ColumnType
    {
        Text,
        Monetary,
        Boolean,
        DateTime,
        Actions
    }
    public class TableColumnConfig<TItem>
    {
        public string Label { get; set; } = "";
        public string Accessor { get; set; } = "";
        public ColumnType Type { get; set; } = ColumnType.Text;
        public Func<TItem, RenderFragment>? RenderActions { get; set; }
    }
}
