using ECommerceApp_API.Core.DTOs.ProductDTOs;
using ECommerceApp_API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp_API.Web.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this._reviewService = reviewService;
        }

        [Authorize]
        [HttpPost]
        [Route("addReview")]
        public async Task<IActionResult> AddReview([FromBody] ReviewDTO reviewDTO, int productId)
        {
            try
            {
                ReviewDTO review = await this._reviewService.AddReviewAsync(reviewDTO, productId);
                return Ok(review);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getReviews")]
        public async Task<IActionResult> GetReviews(int productId, int count, int page)
        {
            try
            {
                List<ReviewDTO> reviews = await this._reviewService.GetReviewsAsync(productId, count, page);
                return Ok(reviews);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
