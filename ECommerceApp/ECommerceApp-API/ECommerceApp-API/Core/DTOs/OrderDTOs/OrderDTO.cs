using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Date { get; set; }
        public decimal Price { get; set; }
        public int PositionsCount { get; set; }
        public int ProductsCount { get; set; }

        public List<Order_Product_DTO> OrderProducts { get; set; } = new();

        public OrderDTO()
        {
            
        }

        public OrderDTO(Order order)
        {
            this.Id = order.Id;
            this.Date = order.Date.ToShortDateString();
            this.Status = order.OrderStatus.Status;
            this.Price = order.TotalPrice;
            this.PositionsCount = order.Products.Count;
            this.ProductsCount = order.Products.Sum(p => p.Count);

            this.OrderProducts = order.Products.Select(p => new Order_Product_DTO(p)).ToList();
        }
    }
}
