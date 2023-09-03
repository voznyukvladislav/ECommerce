namespace ECommerceApp_API.Core.DTOs.ProductDTOs
{
    public class ProductAttributeSetDTO
    {
        public string AttributeSetName { get; set; } = string.Empty;
        public List<ProductAttributeDTO> ProductAttributes { get; set; } = new();
    }
}
