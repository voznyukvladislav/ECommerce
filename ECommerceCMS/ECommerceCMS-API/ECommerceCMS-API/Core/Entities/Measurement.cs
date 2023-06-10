using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MeasurementSet> MeasurementSets { get; set; }
        public List<Attribute> Attributes { get; set; }
    }
}
