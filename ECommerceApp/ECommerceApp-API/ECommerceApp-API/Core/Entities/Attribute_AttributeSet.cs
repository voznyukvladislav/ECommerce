using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Attribute_AttributeSet
    {
        [Key]
        public int Id { get; set; }
        public Attribute Attribute { get; set; } = new Attribute();
        public int AttributeId { get; set; }

        public AttributeSet AttributeSet { get; set; } = new AttributeSet();
        public int AttributeSetId { get; set; }
    }
}
