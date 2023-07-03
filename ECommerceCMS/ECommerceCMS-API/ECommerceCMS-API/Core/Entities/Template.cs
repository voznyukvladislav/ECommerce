using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Template
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AttributeSet> AttributeSets { get; set; } = new List<AttributeSet>();
        public List<Product>? Products { get; set; }

        public Template()
        {

        }
        public Template(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();
            if (nameValue.ContainsKey("Template.Id"))
                this.Id = Int32.Parse(nameValue["Template.Id"]);
            this.Name = nameValue["Template.Name"];

            List<string> attributeSetIds = nameValue["Template.AttributeSets"].Split(' ').ToList();
            attributeSetIds.ForEach(asi =>
            {
                this.AttributeSets.Add(db.AttributeSets.Where(a => a.Id == Int32.Parse(asi)).First());
            });
        }

    }
}
