using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.DTOs.ProductDTOs
{
    public class ReviewDTO
    {
        public int Rating { get; set; }
        public string Text { get; set; } = string.Empty;
        public string ReviewDate { get; set; } = string.Empty;
        public UserDTO User { get; set; } = new();

        public ReviewDTO() { }

        public ReviewDTO(Review review)
        {
            this.User = new UserDTO(review.User);
            this.Rating = review.Rating;
            this.ReviewDate = review.ReviewDate.ToShortDateString() + " " + review.ReviewDate.ToShortTimeString();
            this.Text = review.Text;
        }
    }
}
