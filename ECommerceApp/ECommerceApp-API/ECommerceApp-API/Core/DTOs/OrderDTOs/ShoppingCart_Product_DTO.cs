using ECommerceApp_API.Core.DTOs.ProductDTOs;

namespace ECommerceApp_API.Core.DTOs.OrderDTOs
{
    public class ShoppingCart_Product_DTO
    {
        public int Id { get; set; }
        public int Count { get; set; } = 0;
        public ProductSimpleDTO ProductSimple { get; set; } = new();
    }
}
