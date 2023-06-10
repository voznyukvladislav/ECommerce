using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
