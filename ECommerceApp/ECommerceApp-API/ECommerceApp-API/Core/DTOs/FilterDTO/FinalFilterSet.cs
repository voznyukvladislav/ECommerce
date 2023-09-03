namespace ECommerceApp_API.Core.DTOs.FilterDTO
{
    public class FinalFilterSet
    {
        public List<FinalFilter> FinalFilters { get; set; } = new();
        public PriceFilter PriceFilter { get; set; } = new();
        public string SortingType { get; set; } = string.Empty;
    }
}
