using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public SubCategory SubCategory { get; set; } = new SubCategory();
        public int SubCategoryId { get; set; }

        public Template Template { get; set; } = new Template();
        public int TemplateId { get; set; }

        public Discount? Discount { get; set; } = new Discount();
        public int? DiscountId { get; set; }

        public List<Value> Values { get; set; } = new List<Value>();
        public List<ShoppingCart>? ShoppingCarts { get; set; }
        public List<Photo>? Photos { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Review>? Reviews { get; set; }

        public Product()
        {

        }
    }
}
