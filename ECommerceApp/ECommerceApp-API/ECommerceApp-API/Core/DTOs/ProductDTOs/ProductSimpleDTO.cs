using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.DTOs.ProductDTOs
{
    public class ProductSimpleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int ReviewsCount { get; set; }
        public string BasePrice { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public bool IsDiscounted { get; set; } = false;

        public ProductSimpleDTO()
        {
                
        }

        public ProductSimpleDTO(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Rating = product.Reviews is null ? 0.00 : product.Reviews.Average(r => r.Rating);
            this.ReviewsCount = product.Reviews is null ? 0 : product.Reviews.Count;
            this.BasePrice = Decimal.Floor(product.Price).ToString();
            this.Price = Decimal.Floor(product.Price - product.Price * (product.Discount is null ? 0 : product.Discount.Value)).ToString();
            this.Photo = product.Photos?[0].Source is null ? "" : product.Photos?[0].Source;
            this.IsDiscounted = (product.Price * product.Discount?.Value) < product.Price;
        }
    }
}
