using ECommerceApp_API.Core.DTOs;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp_API.Web.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ISidebarService sidebarService;
        
        public MenuController(ISidebarService sidebarService)
        {
            this.sidebarService = sidebarService;
        }

        [HttpGet]
        [Route("getCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            try
            {
                List<SimpleDTO> categories = await this.sidebarService.GetCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getSubCategories")]
        public async Task<IActionResult> GetSubcategoriesAsync(int categoryId)
        {
            try
            {
                List<SimpleDTO> subCategories = await this.sidebarService.GetSubCategoriesAsync(categoryId);
                return Ok(subCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
