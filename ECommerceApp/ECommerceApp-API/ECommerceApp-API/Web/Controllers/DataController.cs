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
        private readonly ICachedQueriesService _cachedQueriesService;
        public DataController(ECommerceDbContext db, ICachedQueriesService cachedQueriesService)
        {
            this._db = db;
            this._cachedQueriesService = cachedQueriesService;
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

        // Debug methods
        [HttpPost]
        [Route("generateUsers")]
        public IActionResult GenerateUsers()
        {
            try
            {
                List<User> users = DataGenerator.GenerateUsers(_db);
                this._db.Users.AddRange(users);
                this._db.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("generateReviews")]
        public IActionResult GenerateReviews()
        {
            try
            {
                List<User> users = this._db.Users.ToList();
                List<Product> products = this._db.Products.ToList();
                List<Review> reviews = new();
                for (int i = 0; i < users.Count; i++)
                {
                    for (int j = 0; j < products.Count; j++)
                    {
                        reviews.Add(DataGenerator.GenerateReview(users[i], products[j]));
                    }
                }

                this._db.Reviews.AddRange(reviews);
                this._db.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("generateOrderStatuses")]
        public async Task<IActionResult> GenerateOrderStatusesAsync()
        {
            try
            {
                await this._db.OrderStatuses.AddAsync(new OrderStatus() { Status = "Registered" });
                await this._db.OrderStatuses.AddAsync(new OrderStatus() { Status = "Sent" });
                await this._db.OrderStatuses.AddAsync(new OrderStatus() { Status = "Received" });

                await this._db.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
