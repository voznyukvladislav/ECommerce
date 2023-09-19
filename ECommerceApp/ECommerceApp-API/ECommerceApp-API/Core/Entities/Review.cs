using ECommerceApp_API.Core.DTOs.ProductDTOs;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }

        public Product Product { get; set; } = new Product();
        public int ProductId { get; set; }

        public User User { get; set; } = new User();
        public int UserId { get; set; }
        
        public Review()
        {

        }

        public Review(ReviewDTO reviewDTO, Product product, User user, DateTime dateTime)
        {
            this.Text = reviewDTO.Text;
            this.Rating = reviewDTO.Rating;
            this.ReviewDate = dateTime;
            this.Product = product;
            this.ProductId = product.Id;
            this.User = user;
            this.UserId = user.Id;
        }
    }
}
