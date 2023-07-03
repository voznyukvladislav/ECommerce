using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class AttributeSet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Attribute_AttributeSet> Attribute_AttributeSet { get; set; } = new List<Attribute_AttributeSet>();
        public List<Template> Templates { get; set; } = new List<Template>();
        public List<Value> Values { get; set; } = new List<Value>();

        public AttributeSet()
        {

        }
        public AttributeSet(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();
            if (nameValue.ContainsKey("AttributeSet.Id"))
                this.Id = Int32.Parse(nameValue["AttributeSet.Id"]);
            this.Name = nameValue["AttributeSet.Name"];

            List<string> attributesId = nameValue["AttributeSet.Attributes"].Split(' ').ToList();
            attributesId.ForEach(ai =>
            {
                this.Attribute_AttributeSet.Add(new Attribute_AttributeSet 
                { 
                    AttributeId = Int32.Parse(ai),
                    Attribute = db.Attributes.Where(a => a.Id == Int32.Parse(ai)).First(),
                    AttributeSet = this
                });
            });
        }
    }
}
