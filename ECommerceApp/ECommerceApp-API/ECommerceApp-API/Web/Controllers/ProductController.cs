using ECommerceApp_API.Core.DTOs.ProductDTOs;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp_API.Web.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        [Route("getProduct")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            try
            {
                ProductFullDTO productFullDTO = await this._productService.GetProductAsync(productId);
                return Ok(productFullDTO);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getProductRating")]
        public async Task<IActionResult> GetProductRating(int productId)
        {
            try
            {
                return Ok(await this._productService.GetProductRatingAsync(productId));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
