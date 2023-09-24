using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class ShoppingCart_Product
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();

        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = new ShoppingCart();
    }
}
