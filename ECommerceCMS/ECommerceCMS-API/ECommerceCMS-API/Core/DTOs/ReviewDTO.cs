using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public ReviewDTO()
        { }
        public ReviewDTO(Review review)
        {
            this.Id= review.Id;
            this.Text = review.Text;
            this.Rating = review.Rating;
            this.ProductId = review.ProductId;
            this.UserId = review.UserId;
        }
    }
}
