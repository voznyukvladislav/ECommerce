using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.Interfaces
{
    public interface ICachedQueriesService
    {
        public Task<Product> GetProduct(int productId);
    }
}
