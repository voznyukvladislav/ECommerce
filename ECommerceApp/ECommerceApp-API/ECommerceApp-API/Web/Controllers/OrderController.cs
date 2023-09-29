using ECommerceApp_API.Core.DTOs.OrderDTOs;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp_API.Web.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService, IShoppingCartService shoppingCartService)
        {
            this._orderService = orderService;
            this._shoppingCartService = shoppingCartService;
        }

        [Authorize]
        [HttpPost]
        [Route("addOrder")]
        public async Task<IActionResult> AddOrder(List<ShoppingCart_Product_DTO> shoppingCartProducts)
        {
            try
            {
                User user = this._shoppingCartService.GetUserInfo(this.HttpContext.User.Identities.First());
                await this._orderService.AddOrderAsync(user, shoppingCartProducts);
                await this._shoppingCartService.ClearShoppingCart(user);

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("getOrders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                User user = this._shoppingCartService.GetUserInfo(this.HttpContext.User.Identities.First());
                List<OrderDTO> orders = await this._orderService.GetOrders(user);

                return Ok(orders);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("getOrderDetails")]
        public async Task<IActionResult> GetOrderDetails(int orderId)
        {
            try
            {
                OrderDTO orderDTO = await this._orderService.GetOrderDetails(orderId);
                
                return Ok(orderDTO);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
