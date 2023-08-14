using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class AttributeSet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Attribute_AttributeSet> Attribute_AttributeSet { get; set; } = new List<Attribute_AttributeSet>();
        public List<Template> Templates { get; set; } = new List<Template>();
        public List<Value> Values { get; set; } = new List<Value>();

        public AttributeSet()
        {

        }
    }
}
