using ECommerceApp_API.Core.DTOs.ProductDTOs;

namespace ECommerceApp_API.Core.Interfaces
{
    public interface IReviewService
    {
        public Task<ReviewDTO> AddReviewAsync(ReviewDTO reviewDTO, int productId);
        public Task<List<ReviewDTO>> GetReviewsAsync(int productId, int count, int page);
    }
}
