using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        public Product Product { get; set; } = new Product();
        public int ProductId { get; set; }

        public User User { get; set; } = new User();
        public int UserId { get; set; }
        public Review()
        {

        }
        public Review(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();
            if (nameValue.ContainsKey("Review.Id"))
                this.Id = Int32.Parse(nameValue["Review.Id"]);
            this.Text = nameValue["Review.Text"];
            this.Rating = Int32.Parse(nameValue["Review.Rating"]);

            this.ProductId = Int32.Parse(nameValue["Review.ProductId"]);
            this.Product = db.Products.Where(p => p.Id == this.ProductId).First();

            this.UserId = Int32.Parse(nameValue["Review.UserId"]);
            this.User = db.Users.Where(u => u.Id == this.UserId).First();
        }
    }
}
