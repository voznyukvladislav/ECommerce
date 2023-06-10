using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class SubCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public SubCategoryDTO()
        {

        }
        public SubCategoryDTO(SubCategory subCategory)
        {
            this.Id = subCategory.Id;
            this.Name = subCategory.Name;
            this.CategoryId = subCategory.CategoryId;
        }
    }
}
