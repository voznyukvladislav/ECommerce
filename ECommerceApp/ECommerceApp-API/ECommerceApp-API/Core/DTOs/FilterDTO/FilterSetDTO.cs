namespace ECommerceApp_API.Core.DTOs.FilterDTO
{
    public class FilterSetDTO
    {
        public string SortingType { get; set; } = string.Empty;
        public PriceFilter PriceFilter { get; set; } = new();
        public List<AttributeSetFilter> AttributeSetFilters { get; set; } = new();
    }
}
