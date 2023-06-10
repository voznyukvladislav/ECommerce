using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Template Template { get; set; }
        public int TemplateId { get; set; }

        public List<Value> Values { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }

        public Discount Discount { get; set; }
        public int DiscountId { get; set; }

        public List<Order> Orders { get; set; }
        public List<Review> Reviews { get; set; }

        public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; } 
    }
}
