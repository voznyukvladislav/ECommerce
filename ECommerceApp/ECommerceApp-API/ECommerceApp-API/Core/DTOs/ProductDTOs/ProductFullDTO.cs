using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.DTOs.ProductDTOs
{
    public class ProductFullDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> Photos { get; set; } = new();
        public List<ProductAttributeSetDTO> AttributeSets { get; set; } = new();

        public ProductFullDTO()
        {
               
        }

        public ProductFullDTO(Product product)
        {
            this.Name = product.Name;
            this.Price = product.Price;
            this.Photos = product.Photos!
                .Select(p => p.Source)
                .ToList();

            product.Template.AttributeSets.ForEach(a =>
            {
                List<ProductAttributeDTO> productAttributes = new();
                a.Attribute_AttributeSet.ForEach(aas =>
                {
                    productAttributes.Add(new ProductAttributeDTO()
                    {
                        AttributeName = aas.Attribute.Name,
                        Value = aas.Values[0].Val
                    });
                });
                
                this.AttributeSets.Add(new ProductAttributeSetDTO()
                {
                    AttributeSetName = a.Name,
                    ProductAttributes = productAttributes
                });
            });
        }
    }
}
