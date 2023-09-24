using ECommerceApp_API.Core.DTOs.OrderDTOs;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using System.Security.Claims;

namespace ECommerceApp_API.Core.Interfaces
{
    public interface IShoppingCartService
    {
        public Task AddShoppingCartProductAsync(User user, int productId);
        public Task RemoveShoppingCartProductAsync(User user, int productId);
        public Task<List<ShoppingCart_Product_DTO>> GetShoppingCartAsync(User user);
        public Task UpdateShoppingCartProductCountAsync(User user, int productId, int count);
        public User GetUserInfo(ClaimsIdentity claimsIdentity);
    }
}
