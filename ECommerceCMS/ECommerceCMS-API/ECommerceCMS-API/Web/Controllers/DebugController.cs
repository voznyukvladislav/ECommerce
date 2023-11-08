using ECommerceCMS_API.Core.Entities;
using ECommerceCMS_API.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceCMS_API.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebugController : ControllerBase
    {
        private readonly ECommerceDbContext _db;
        public DebugController(ECommerceDbContext db)
        {
            this._db = db;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("purgeDb")]
        public IActionResult Delete()
        {
            this._db.Attributes.RemoveRange(this._db.Attributes.Include(a => a.Attribute_AttributeSet).ThenInclude(a => a.AttributeSet).ToList());
            this._db.AttributeSets.RemoveRange(this._db.AttributeSets.ToList());
            this._db.Attribute_AttributeSets.RemoveRange(this._db.Attribute_AttributeSets.ToList());
            this._db.Categories.RemoveRange(this._db.Categories.ToList());
            this._db.Discounts.RemoveRange(this._db.Discounts.ToList());
            this._db.Measurements.RemoveRange(this._db.Measurements.ToList());
            this._db.MeasurementSets.RemoveRange(this._db.MeasurementSets.ToList());
            this._db.Orders.RemoveRange(this._db.Orders.ToList());
            this._db.Photos.RemoveRange(this._db.Photos.ToList());
            this._db.Products.RemoveRange(this._db.Products.ToList());
            this._db.Reviews.RemoveRange(this._db.Reviews.ToList());
            this._db.Roles.RemoveRange(this._db.Roles.ToList());
            this._db.ShoppingCarts.RemoveRange(this._db.ShoppingCarts.ToList());
            this._db.SubCategories.RemoveRange(this._db.SubCategories.ToList());
            this._db.Templates.RemoveRange(this._db.Templates.ToList());
            this._db.Users.RemoveRange(this._db.Users.ToList());
            this._db.Values.RemoveRange(this._db.Values.ToList());

            this._db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("seedDb")]
        public IActionResult SeedDb()
        {
            try
            {
                DataSeeder.SeedRoles(_db);
                DataSeeder.SeedUsers(_db);
                DataSeeder.SeedOrderStatuses(_db);
                DataSeeder.SeedDiscounts(_db);

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("generateUsers")]
        public IActionResult GenerateUsers([FromQuery] int usersNum)
        {
            try
            {
                List<User> users = DataGenerator.GenerateUsers(_db, usersNum);
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
        [Route("deleteUsers")]
        public IActionResult DeleteUsers()
        {
            try
            {
                this._db.Users.RemoveRange(this._db.Users.ToList());
                this._db.SaveChanges();

                Role adminRole = this._db.Roles.Where(r => r.Name == "Admin").First();
                User admin = new User()
                {
                    Email = "admin@mail.com",
                    Login = "Admin",
                    Password = "123321",
                    Role = adminRole,
                    RoleId = adminRole.Id,
                    ShoppingCarts = new List<ShoppingCart>(),
                    Name = "",
                    Surname = "",
                    Phone = ""
                };
                admin.ShoppingCarts.Add(new ShoppingCart() { User = admin });
                admin.Password = Hashing.Hash(admin.Password);

                this._db.Users.Add(admin);
                this._db.SaveChanges();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
