using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }       
        public string Name { get; set; }

        public Category Category { get; set; } = new Category();
        public int CategoryId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public SubCategory()
        {

        }
        public SubCategory(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValues = inputBlockDTO.GetNameValueDictionary();
            if (nameValues.ContainsKey("SubCategory.Id"))
                this.Id = Int32.Parse(nameValues["SubCategory.Id"]);
            this.Name = nameValues["SubCategory.Name"];
            this.CategoryId = Int32.Parse(nameValues["SubCategory.CategoryId"]);
            this.Category = db.Categories.Where(c => c.Id == this.CategoryId).First();
        }
    }
}
