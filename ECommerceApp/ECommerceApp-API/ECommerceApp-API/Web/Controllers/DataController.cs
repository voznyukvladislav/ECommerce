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
                    .FirstOrDefault()!;

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

        [HttpGet]
        [Route("getProduct")]
        public async Task<IActionResult> GetProductAsync(int productId)
        {
            try
            {
                Product product = await this._cachedQueriesService.GetProduct(productId);
                /*product.Reviews = await this._db.Reviews
                    .Where(r => r.ProductId == productId)
                    .ToListAsync();*/

                ProductFullDTO productFullDTO = new ProductFullDTO(product, this._db);
                productFullDTO.AttributeSets = productFullDTO
                    .AttributeSets.OrderBy(a => a.AttributeSetName)
                    .ToList();

                productFullDTO.AttributeSets.ForEach(a =>
                {
                    a.ProductAttributes = a.ProductAttributes
                        .OrderBy(pa => pa.AttributeName)
                        .ToList();
                });

                return Ok(productFullDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getReviews")]
        public async Task<IActionResult> GetReviewsAsync(int productId, int count, int page)
        {
            try
            {
                List<Review>? reviews = await this._db.Reviews
                    .Where(r => r.ProductId == productId)
                    .Include(r => r.User)
                    .OrderByDescending(r => r.ReviewDate)
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToListAsync();

                List<ReviewDTO> reviewDTOs = new();
                reviews.ForEach(r =>
                {
                    reviewDTOs.Add(new ReviewDTO(r));
                });

                return Ok(reviewDTOs);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        [Route("addReview")]
        public IActionResult AddReview([FromBody] ReviewDTO reviewDTO, int productId)
        {
            try
            {
                Product product = this._db.Products
                    .Where(p => p.Id == productId)
                    .First();
                User user = this._db.Users
                    .Where(u => u.Login == reviewDTO.User.Login)
                    .First();

                Review review = new Review(reviewDTO, product, user, DateTime.Now);
                
                this._db.Reviews.Add(review);
                this._db.SaveChanges();

                return Ok(new ReviewDTO(review));
            }
            catch
            {
                return BadRequest();
            }
        }

        /*[Authorize]
        [HttpPost]
        [Route("addShoppingCartProduct")]
        public IActionResult AddShoppingCartProduct(int productId)
        {
            try
            {
                Product product = this._db.Products
                    .Where(p => p.Id == productId)
                    .First();

                var email = this.HttpContext.User.Identities.ElementAt(0).Claims
                    .Where(c => c.Type == ClaimTypes.Email)
                    .Select(c => c.Value)
                    .First();

                User user = this._db.Users
                    .Where(u => u.Email == email)
                    .Include(u => u.ShoppingCarts)
                    .ThenInclude(sc => sc.Products!)
                    .ThenInclude(p => p.Product)
                    .First();

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

                    this._db.SaveChanges();
                }

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        [Route("updateShoppingCartProductCount")]
        public IActionResult UpdateShoppingCartProductCount(int productId, int count)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("getShoppingCart")]
        public IActionResult GetShoppingCart()
        {
            try
            {
                var email = this.HttpContext.User.Identities.ElementAt(0).Claims
                    .Where(c => c.Type == ClaimTypes.Email)
                    .Select(c => c.Value)
                    .First();

                User user = this._db.Users
                    .Where(u => u.Email == email)
                    .Include(u => u.ShoppingCarts)
                    .ThenInclude(sc => sc.Products!)
                    .ThenInclude(p => p.Product)
                    .ThenInclude(p => p.Photos)

                    .Include(u => u.ShoppingCarts)
                    .ThenInclude(sc => sc.Products!)
                    .ThenInclude(p => p.Product)
                    .ThenInclude(p => p.Discount)

                    .First();

                List<ShoppingCart_Product_DTO> shoppingCartProductDTOs = user.ShoppingCarts
                    .First()
                    .Products!.Select(p => new ShoppingCart_Product_DTO { 
                        Id = p.Id,
                        Count = p.Count,
                        ProductSimple = new ProductSimpleDTO(p.Product)
                    })
                    .ToList();

                return Ok(shoppingCartProductDTOs);
            }
            catch
            {
                return BadRequest();
            }
        }*/

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
    }
}
