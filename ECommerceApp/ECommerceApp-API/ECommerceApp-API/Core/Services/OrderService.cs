using ECommerceApp_API.Core.DTOs.OrderDTOs;
using ECommerceApp_API.Core.Entities;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp_API.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ECommerceDbContext _db;
        public OrderService(ECommerceDbContext db)
        {
            this._db = db;
        }
        public async Task AddOrderAsync(User user, List<ShoppingCart_Product_DTO> shoppingCartProducts)
        {
            Order order = new Order();
            order.User = user;
            order.UserId = user.Id;
            order.Date = DateTime.Now;

            OrderStatus orderStatus = this._db.OrderStatuses
                .Where(os => os.Status == "Registered")
                .First();

            order.OrderStatus = orderStatus;
            order.OrderStatusId = orderStatus.Id;

            shoppingCartProducts.ForEach(scp =>
            {
                Product product = this._db.Products
                    .Where(p => p.Id == scp.ProductSimple.Id)
                    .First();

                order.Products.Add(new Order_Product()
                {
                    Count = scp.Count,
                    Price = Convert.ToDecimal(scp.ProductSimple.Price),
                    TotalPrice = Convert.ToDecimal(scp.ProductSimple.Price) * scp.Count,
                    Order = order,
                    ProductId = product.Id,
                    Product = product
                });
            });
            order.Products.ForEach(op =>
            {
                order.TotalPrice += op.TotalPrice;
            });

            await this._db.Orders.AddAsync(order);
            await this._db.SaveChangesAsync();
        }

        public async Task<List<OrderDTO>> GetOrders(User user)
        {
            List<Order> orders = await this._db.Orders
                .Where(o => o.UserId == user.Id)
                .Include(o => o.OrderStatus)
                .Include(o => o.Products)
                .ThenInclude(op => op.Product)
                .ThenInclude(p => p.Photos)
                .ToListAsync();

            List<OrderDTO> orderDTOs = orders.Select(o => new OrderDTO(o)).ToList();
            orderDTOs = orderDTOs.OrderByDescending(o => o.Date).ToList();

            return orderDTOs;
        }

        public async Task<OrderDTO> GetOrderDetails(int orderId)
        {
            Order order = await this._db.Orders
                .Where(o => o.Id == orderId)
                .Include(o => o.OrderStatus)
                .Include(o => o.Products)
                .ThenInclude(op => op.Product)
                .ThenInclude(p => p.Photos)
                .FirstAsync();

            return new OrderDTO(order);
        }
    }
}
