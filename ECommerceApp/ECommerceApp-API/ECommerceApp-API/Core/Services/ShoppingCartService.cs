using ECommerceApp_API.Core.DTOs.OrderDTOs;
using ECommerceApp_API.Core.DTOs.ProductDTOs;
using ECommerceApp_API.Core.Entities;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECommerceApp_API.Core.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ECommerceDbContext _db;
        public ShoppingCartService(ECommerceDbContext db)
        {
            this._db = db;
        }

        public async Task ClearShoppingCart(User user)
        {
            ShoppingCart shoppingCart = await this._db.ShoppingCarts
                .Where(sc => sc.UserId == user.Id)
                .Include(sc => sc.Products!)
                .ThenInclude(scp => scp.Product)
                .FirstAsync();

            shoppingCart.Products?.ForEach(scp =>
            {
                this._db.ShoppingCart_Product.Remove(scp);
            });

            await this._db.SaveChangesAsync();
        }

        public async Task AddShoppingCartProductAsync(User user, int productId)
        {
            Product product = await this._db.Products
                    .Where(p => p.Id == productId)
                    .FirstAsync();

            user = await this._db.Users
                .Where(u => u.Id == user.Id)
                .Include(u => u.ShoppingCarts)
                .ThenInclude(sc => sc.Products!)
                .ThenInclude(p => p.Product)
                .FirstAsync();

            ShoppingCart shoppingCart = user.ShoppingCarts.First();
            if (shoppingCart.Products is null)
                shoppingCart.Products = new();

            // If such product is not already in shopping cart
            if (shoppingCart.Products.Where(scp => scp.ProductId == productId).FirstOrDefault() is null)
            {
                shoppingCart.Products.Add(new Core.Entities.ShoppingCart_Product
                {
                    ProductId = productId,
                    Product = product,
                    ShoppingCart = shoppingCart,
                    ShoppingCartId = shoppingCart.Id,
                    Count = 1
                });

                await this._db.SaveChangesAsync();
            }
        }

        public async Task RemoveShoppingCartProductAsync(User user, int productId)
        {
            ShoppingCart shoppingCart = await this._db.ShoppingCarts
                .Where(sc => sc.UserId == user.Id)
                .Include(sc => sc.Products)
                .FirstAsync();

            var shoppingCartProduct = shoppingCart.Products
                .Where(p => p.ProductId == productId && p.ShoppingCartId == shoppingCart.Id)
                .First();

            this._db.ShoppingCart_Product.Remove(shoppingCartProduct);
            await this._db.SaveChangesAsync();
        }

        public async Task UpdateShoppingCartProductCountAsync(User user, int productId, int count)
        {
            ShoppingCart shoppingCart = await this._db.ShoppingCarts
                .Where(sc => sc.UserId == user.Id)
                .Include(sc => sc.Products)
                .FirstAsync();

            var shoppingCartProduct = shoppingCart.Products
                .Where(p => p.ProductId == productId && p.ShoppingCartId == shoppingCart.Id)
                .First();

            shoppingCartProduct.Count = count;

            await this._db.SaveChangesAsync();
        }

        public async Task<List<ShoppingCart_Product_DTO>> GetShoppingCartAsync(User user)
        {
            user = await this._db.Users
                    .Where(u => u.Id == user.Id)
                    .Include(u => u.ShoppingCarts)
                    .ThenInclude(sc => sc.Products!)
                    .ThenInclude(p => p.Product)
                    .ThenInclude(p => p.Photos)

                    .Include(u => u.ShoppingCarts)
                    .ThenInclude(sc => sc.Products!)
                    .ThenInclude(p => p.Product)
                    .ThenInclude(p => p.Discount)

                    .FirstAsync();

            List<ShoppingCart_Product_DTO> shoppingCartProductDTOs = user.ShoppingCarts
                .First()
                .Products!.Select(p => new ShoppingCart_Product_DTO
                {
                    Id = p.Id,
                    Count = p.Count,
                    ProductSimple = new ProductSimpleDTO(p.Product)
                })
                .ToList();

            return shoppingCartProductDTOs;
        }

        public User GetUserInfo(ClaimsIdentity claimsIdentity)
        {
            var email = claimsIdentity.Claims
                    .Where(c => c.Type == ClaimTypes.Email)
                    .Select(c => c.Value)
                    .First();

            User user = this._db.Users
                .Where(u => u.Email == email)
                .First();

            return user;
        }
    }
}
