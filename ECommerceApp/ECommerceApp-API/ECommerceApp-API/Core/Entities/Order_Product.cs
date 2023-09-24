using ECommerceCMS_API.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp_API.Core.Entities
{
    public class Order_Product
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = new();

        public int OrderId { get; set; }
        public Order Order { get; set; } = new();
    }
}
