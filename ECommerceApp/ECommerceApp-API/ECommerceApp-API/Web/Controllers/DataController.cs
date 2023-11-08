using ECommerceApp_API.Core.DTOs;
using ECommerceApp_API.Core.DTOs.OrderDTOs;
using ECommerceApp_API.Core.DTOs.ProductDTOs;
using ECommerceApp_API.Core.Entities;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECommerceApp_API.Web.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ECommerceDbContext _db;
        public DataController(ECommerceDbContext db)
        {
            this._db = db;
        }

        [HttpGet]
        [Route("getSubCategoryParent")]
        public IActionResult GetSubCategoryParent(int subCategoryId)
        {
            try
            {
                SubCategory subCategory = this._db.SubCategories
                    .Where(s => s.Id == subCategoryId)
                    .Include(s => s.Category)
                    .FirstOrDefault()!;

                SimpleDTO categoryDTO = new SimpleDTO();
                categoryDTO.Id = $"{subCategory.Category.Id}";
                categoryDTO.Name = subCategory.Category.Name;

                return Ok(categoryDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getSubCategory")]
        public IActionResult GetSubCategory(int subCategoryId)
        {
            try
            {
                SubCategory subCategory = this._db.SubCategories
                    .Where(s => s.Id == subCategoryId)
                    .First();

                SimpleDTO subCategoryDTO = new SimpleDTO();
                subCategoryDTO.Id = $"{subCategory.Id}";
                subCategoryDTO.Name = subCategory.Name;

                return Ok(subCategoryDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
