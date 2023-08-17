using ECommerceApp_API.Core.DTOs;
using ECommerceApp_API.Core.Interfaces;
using ECommerceApp_API.Infrastructure.Data;
using ECommerceCMS_API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp_API.Core.Services
{
    public class SidebarService : ISidebarService
    {
        private readonly ECommerceDbContext db;
        public SidebarService(ECommerceDbContext db)
        {
            this.db = db;
        }

        public async Task<List<SimpleDTO>> GetCategoriesAsync()
        {
            List<SimpleDTO> categoriesSimple = new List<SimpleDTO>();
            List<Category> categories = await this.db.Categories.ToListAsync();
            categories.ForEach(c =>
            {
                categoriesSimple.Add(new SimpleDTO() { Id = $"{c.Id}", Name = $"{c.Name}" });
            });

            return categoriesSimple;
        }

        public async Task<List<SimpleDTO>> GetSubCategoriesAsync(int categoryId)
        {
            List<SimpleDTO> subCategoriesSimple = new List<SimpleDTO>();
            List<SubCategory> subCategories = await this.db.SubCategories
                .Include(s => s.Category)
                .Where(s => s.CategoryId == categoryId)
                .ToListAsync();

            subCategories.ForEach(s =>
            {
                subCategoriesSimple.Add(new SimpleDTO() { Id = $"{s.Id}", Name = $"{s.Name}" });
            });

            return subCategoriesSimple;
        }
    }
}
