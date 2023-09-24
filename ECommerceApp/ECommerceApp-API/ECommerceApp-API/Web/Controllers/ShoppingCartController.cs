using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp_API.Web.Controllers
{
    [Authorize]
    [Route("api/shoppingCart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ECommerceDbContext _db;
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(ECommerceDbContext db, IShoppingCartService shoppingCartService)
        {
            this._db = db;
            this._shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        [Route("getShoppingCart")]
        public async Task<IActionResult> GetShoppingCartAsync()
        {
            try
            {
                User user = this._shoppingCartService.GetUserInfo(this.HttpContext.User.Identities.First());
                var products = await this._shoppingCartService.GetShoppingCartAsync(user);

                return Ok(products);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("addShoppingCartProduct")]
        public async Task<IActionResult> AddShoppingCartProductAsync([FromQuery] int productId)
        {
            try
            {
                User user = this._shoppingCartService.GetUserInfo(this.HttpContext.User.Identities.First());
                await this._shoppingCartService.AddShoppingCartProductAsync(user, productId);
            
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        
        [HttpPatch]
        [Route("updateShoppingCartProductCount")]
        public async Task<IActionResult> UpdateShoppingCartProductCount([FromQuery] int productId, [FromQuery] int count)
        {
            try
            {
                User user = this._shoppingCartService.GetUserInfo(this.HttpContext.User.Identities.First());
                await this._shoppingCartService.UpdateShoppingCartProductCountAsync(user, productId, count);

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("removeShoppingCartProduct")]
        public async Task<IActionResult> RemoveShoppingCartProduct([FromQuery] int productId) {
            try
            {
                User user = this._shoppingCartService.GetUserInfo(this.HttpContext.User.Identities.First());
                await this._shoppingCartService.RemoveShoppingCartProductAsync(user, productId);

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
