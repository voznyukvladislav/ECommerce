using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Attribute
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Measurement Measurement { get; set; }
        public int MeasurementId { get; set; }
        public List<AttributeSet> AttributeSets { get; set; } = new List<AttributeSet>();
    }
}
