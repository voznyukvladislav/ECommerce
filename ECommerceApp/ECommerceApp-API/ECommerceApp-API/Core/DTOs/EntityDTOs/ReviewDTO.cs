using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public ReviewDTO()
        { }
        public ReviewDTO(Review review)
        {
            Id = review.Id;
            Text = review.Text;
            Rating = review.Rating;
            ProductId = review.ProductId;
            UserId = review.UserId;
        }
    }
}
