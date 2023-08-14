using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class SubCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public SubCategoryDTO()
        {

        }
        public SubCategoryDTO(SubCategory subCategory)
        {
            Id = subCategory.Id;
            Name = subCategory.Name;
            CategoryId = subCategory.CategoryId;
        }
    }
}
