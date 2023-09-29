using ECommerceApp_API.Core.DTOs.OrderDTOs;
using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.Interfaces
{
    public interface IOrderService
    {
        public Task AddOrderAsync(User user, List<ShoppingCart_Product_DTO> shoppingCartProducts);
        public Task<List<OrderDTO>> GetOrders(User user);
        public Task<OrderDTO> GetOrderDetails(int orderId);
    }
}
