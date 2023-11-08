using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.DTOs.ProductDTOs
{
    public class ProductFullDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int ReviewsCount { get; set; }
        public string BasePrice { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public List<string> Photos { get; set; } = new();
        public List<ProductAttributeSetDTO> AttributeSets { get; set; } = new();
        public List<ReviewDTO> Reviews { get; set; } = new();

        public ProductFullDTO() { }

        public ProductFullDTO(Product product, ECommerceDbContext db)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Rating = product.Reviews is null ? 0.00 : product.Reviews.Average(r => r.Rating);
            this.ReviewsCount = db.Reviews.Where(r => r.ProductId == product.Id).Count();
            this.BasePrice = Decimal.Floor(product.Price).ToString();
            this.Price = Decimal.Floor(product.Price - product.Price * (product.Discount is null ? 0 : product.Discount.Value)).ToString();
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
                        AttributeId = aas.AttributeId,
                        AttributeName = aas.Attribute.Name,
                        Value = aas.Values[0].Val,
                        Measurement = aas.Values[0].Measurement is null ? "" : aas.Values[0].Measurement.Name
                    });
                });
                
                this.AttributeSets.Add(new ProductAttributeSetDTO()
                {
                    AttributeSetId = a.Id,
                    AttributeSetName = a.Name,
                    ProductAttributes = productAttributes
                });
            });

            product?.Reviews?.ForEach(r =>
            {
                this.Reviews.Add(new ReviewDTO(r));
            });
        }
    }
}
