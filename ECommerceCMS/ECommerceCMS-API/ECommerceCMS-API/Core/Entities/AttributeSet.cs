using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class AttributeSet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Attribute> Attributes { get; set; }
        public List<Template> Templates { get; set; }
        public List<Value> Values { get; set; }
    }
}
