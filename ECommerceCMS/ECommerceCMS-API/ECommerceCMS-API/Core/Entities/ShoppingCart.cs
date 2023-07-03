using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public User User { get; set; } = new User();
        public int UserId { get; set; }
    }
}
