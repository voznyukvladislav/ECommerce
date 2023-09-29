using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Order_Product
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = new();

        public int OrderId { get; set; }
        public Order Order { get; set; } = new();
    }
}
