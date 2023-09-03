using ECommerceApp_API.Core.DTOs.FilterDTO;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.Interfaces
{
    public interface IFilterService
    {
        public FilterSetDTO GetSendingFilter(ECommerceDbContext db, int subCategoryId);
        public FinalFilterSet GetFinalFilterSet(FilterSetDTO filterSetDTO);
        public List<Product> GetProducts(ECommerceDbContext db, FinalFilterSet finalFilterSet, int subCategoryId);
        public int GetCheckedCount(FilterSetDTO filterSetDTO);
    }
}
