using ECommerceApp_API.Core.DTOs.ProductDTOs;

namespace ECommerceApp_API.Core.Interfaces
{
    public interface IProductService
    {
        public Task<ProductFullDTO> GetProductAsync(int productId);
        public Task<double> GetProductRatingAsync(int productId);
    }
}
