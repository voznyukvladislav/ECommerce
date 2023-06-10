using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Value
    {
        [Key]
        public int Id { get; set; }
        public string Val { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public AttributeSet AttributeSet { get; set; }
        public int AttributeSetId { get; set; }

        public Attribute Attribute { get; set; }
        public int AttributeId { get; set; }
    }
}
