namespace ECommerceApp_API.Core.DTOs.ProductDTOs
{
    public class ProductAttributeSetDTO
    {
        public int AttributeSetId { get; set; }
        public string AttributeSetName { get; set; } = string.Empty;
        public List<ProductAttributeDTO> ProductAttributes { get; set; } = new();
    }
}
