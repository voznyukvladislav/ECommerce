using ECommerceApp_API.Core.DTOs.ProductDTOs;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp_API.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ECommerceDbContext _db;

        public ReviewService(ECommerceDbContext db)
        {
            this._db = db;
        }

        public async Task<ReviewDTO> AddReviewAsync(ReviewDTO reviewDTO, int productId)
        {
            Product product = await this._db.Products
                    .Where(p => p.Id == productId)
                    .FirstAsync();
            User user = await this._db.Users
                .Where(u => u.Login == reviewDTO.User.Login)
                .FirstAsync();

            Review review = new Review(reviewDTO, product, user, DateTime.Now);

            await this._db.Reviews.AddAsync(review);
            await this._db.SaveChangesAsync();

            return new ReviewDTO(review);
        }

        public async Task<List<ReviewDTO>> GetReviewsAsync(int productId, int count, int page)
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

            return reviewDTOs;
        }
    }
}
