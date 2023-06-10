using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubCategories { get; set; }
        public CategoryDTO()
        {

        }
        public CategoryDTO(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.SubCategories = String.Join(", ", category.SubCategories.Select(s => s.Id));
        }
    }
}
