using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Template
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<AttributeSet> AttributeSets { get; set; } = new List<AttributeSet>();
        public List<Product>? Products { get; set; }

        public Template()
        {

        }
    }
}
