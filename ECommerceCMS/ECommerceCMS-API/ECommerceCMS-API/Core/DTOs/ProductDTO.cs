using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string TemplateId { get; set; }
        public string DiscountId { get; set; }
        public string SubCategoryId { get; set; }
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
            this.Price = product.Price.ToString();
            this.TemplateId = product.TemplateId.ToString();
            this.DiscountId = product.DiscountId.ToString();
            this.SubCategoryId = product.SubCategoryId.ToString();
            if(product.Orders is not null)
                this.Orders = String.Join(", ", product.Orders.Select(o => o.Id));
            if(product.Reviews is not null)
                this.Reviews = String.Join(", ", product.Reviews.Select(r => r.Id));
            if(product.ShoppingCarts is not null)
                this.ShoppingCarts = String.Join(", ", product.ShoppingCarts.Select(sc => sc.Id));
            if(product.Values.Count != 0)
                this.Values = String.Join(", ", product.Values.Select(v => v.Id));
        }
    }
}
