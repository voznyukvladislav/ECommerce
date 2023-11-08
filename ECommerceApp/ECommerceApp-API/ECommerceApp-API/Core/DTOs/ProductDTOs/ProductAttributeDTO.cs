namespace ECommerceApp_API.Core.DTOs.ProductDTOs
{
    public class ProductAttributeDTO
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Measurement { get; set; } = string.Empty;
    }
}
