namespace ECommerceApp_API.Core.DTOs.FilterDTO
{
    public class FilterValue
    {
        public string Value { get; set; } = string.Empty;
        public int Count { get; set; }
        public bool IsChecked { get; set; } = false;
    }
}
