using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class Order_Product_DTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Count { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string TotalPrice { get; set; } = string.Empty;

        public Order_Product_DTO()
        {
                
        }

        public Order_Product_DTO(Order_Product orderProduct)
        {
            this.Id = orderProduct.Id;
            this.ProductId = orderProduct.ProductId;
            this.OrderId = orderProduct.OrderId;
            this.Count = $"{orderProduct.Count}";
            this.Price = $"{orderProduct.Price}";
            this.TotalPrice = $"{orderProduct.TotalPrice}";
        }
    }
}
