using ECommerceApp_API.Core.Entities;

namespace ECommerceApp_API.Core.DTOs.OrderDTOs
{
    public class Order_Product_DTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Photo { get; set; } = string.Empty;
        public int Count { get; set; }

        public Order_Product_DTO()
        {
            
        }

        public Order_Product_DTO(Order_Product order_Product)
        {
            this.ProductId = order_Product.ProductId;
            this.Name = order_Product.Product.Name;
            this.Price = order_Product.Product.Price;
            this.TotalPrice = order_Product.Product.Price * order_Product.Count;
            this.Count = order_Product.Count;
            this.Photo = order_Product.Product.Photos.First().Source;
        }
    }
}
