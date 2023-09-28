using ECommerceApp_API.Core.DTOs.ProductDTOs;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp_API.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ICachedQueriesService _cachedQueriesService;
        private readonly ECommerceDbContext _db;

        public ProductService(ICachedQueriesService cachedQueriesService, ECommerceDbContext db)
        {
            this._cachedQueriesService = cachedQueriesService;
            this._db = db;
        }

        public async Task<ProductFullDTO> GetProductAsync(int productId)
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

            return productFullDTO;
        }

        public async Task<double> GetProductRatingAsync(int productId)
        {
            List<Review> reviews = await this._db.Reviews
                .Where(r => r.ProductId == productId)
                .ToListAsync();

            return reviews.Average(r => r.Rating);
        }
    }
}
