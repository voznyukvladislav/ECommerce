namespace ECommerceApp_API.Core.DTOs.FilterDTO
{
    public class AttributeSetFilter
    {
        public int AttributeSetId { get; set; }
        public string AttributeSetName { get; set; } = string.Empty;
        public List<AttributeFilter> AttributeFilters { get; set; } = new();
    }
}
