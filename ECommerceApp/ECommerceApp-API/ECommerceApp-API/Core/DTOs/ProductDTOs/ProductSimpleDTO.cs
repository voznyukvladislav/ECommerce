using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.DTOs.ProductDTOs
{
    public class ProductSimpleDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Photo { get; set; } = string.Empty;

        public ProductSimpleDTO()
        {
                
        }

        public ProductSimpleDTO(Product product)
        {
            this.Name = product.Name;
            this.Price = product.Price;
            this.Photo = product.Photos?[0].Source is null ? "" : product.Photos?[0].Source;
        }
    }
}
