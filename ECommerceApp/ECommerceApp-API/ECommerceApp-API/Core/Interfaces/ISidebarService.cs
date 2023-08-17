using ECommerceApp_API.Core.DTOs;

namespace ECommerceApp_API.Core.Interfaces
{
    public interface ISidebarService
    {
        public Task<List<SimpleDTO>> GetCategoriesAsync();
        public Task<List<SimpleDTO>> GetSubCategoriesAsync(int categoryId);
    }
}
