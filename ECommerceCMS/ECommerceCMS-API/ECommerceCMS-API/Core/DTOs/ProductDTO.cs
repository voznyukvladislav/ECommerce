using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TemplateId { get; set; }
        public int DiscountId { get; set; }
        public int SubCategoryId { get; set; }
        public string Orders { get; set; }
        public string Reviews { get; set; }
        public string ShoppingCarts { get; set; }
        public string Values { get; set; }

        public ProductDTO()
        { }
        public ProductDTO(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.TemplateId = product.TemplateId;
            this.DiscountId = product.DiscountId;
            this.SubCategoryId = product.SubCategoryId;
            this.Orders = String.Join(", ", product.Orders.Select(o => o.Id));
            this.Reviews = String.Join(", ", product.Reviews.Select(r => r.Id));
            this.ShoppingCarts = String.Join(", ", product.ShoppingCarts.Select(sc => sc.Id));
            this.Values = String.Join(", ", product.Values.Select(v => v.Id));
        }
    }
}
