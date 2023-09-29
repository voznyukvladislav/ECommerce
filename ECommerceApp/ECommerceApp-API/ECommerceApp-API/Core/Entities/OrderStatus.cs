using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new();
    }
}
