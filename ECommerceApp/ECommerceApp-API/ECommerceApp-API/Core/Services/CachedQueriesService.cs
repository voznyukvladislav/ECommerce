using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ECommerceApp_API.Core.Services
{
    public class CachedQueriesService : ICachedQueriesService
    {
        private readonly ECommerceDbContext _db;
        private readonly IMemoryCache _cache;

        public CachedQueriesService(ECommerceDbContext db, IMemoryCache cache)
        {
            this._db = db;
            this._cache = cache;
        }

        public async Task<Product> GetProduct(int productId)
        {
            this._cache.TryGetValue(productId, out Product? product);

            if (product is null)
            {
                product = await this._db.Products
                    .Where(p => p.Id == productId)

                    .Include(p => p.Template)
                    .ThenInclude(t => t.AttributeSets)
                    .ThenInclude(a => a.Attribute_AttributeSet)
                    .ThenInclude(aas => aas.Attribute)

                    .Include(p => p.Photos)
                    .Include(p => p.Discount)
                    .Include(p => p.Values)
                    .ThenInclude(v => v.Attribute_AttributeSet)

                    .Include(p => p.Values)
                    .ThenInclude(v => v.Measurement)

                    .FirstOrDefaultAsync();

                if (product is not null)
                {
                    /*product.Reviews = await this._db.Reviews
                        .Where(r => r.ProductId == productId)
                        .Include(r => r.User)
                        .ToListAsync();*/

                    this._cache.Set(productId, product);

                    return product;
                }
                else
                {
                    throw new ArgumentException(nameof(productId));
                }
            }

            return product;
        }
    }
}
