namespace ECommerceApp_API.Core.DTOs.FilterDTO
{
    public class FinalFilter
    {
        public int AttributeSetId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; } = string.Empty;
    }
}
