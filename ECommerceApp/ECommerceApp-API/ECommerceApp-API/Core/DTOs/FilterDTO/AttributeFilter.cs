namespace ECommerceApp_API.Core.DTOs.FilterDTO
{
    public class AttributeFilter
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; } = string.Empty;
        public List<FilterValue> Values { get; set; } = new();
    }
}
