using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SubCategories { get; set; } = string.Empty;
        public CategoryDTO()
        {

        }
        public CategoryDTO(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            if (category.SubCategories.Count != 0)
                SubCategories = string.Join(", ", category.SubCategories.Select(s => s.Id));
        }
    }
}
