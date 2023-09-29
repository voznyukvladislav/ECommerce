using ECommerceApp_API.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; } = new User();
        public int UserId { get; set; }

        public OrderStatus OrderStatus { get; set; } = new();
        public int OrderStatusId { get; set; }

        public decimal TotalPrice { get; set; }

        public List<Order_Product> Products { get; set; } = new();

        public Order()
        {

        }
    }
}
