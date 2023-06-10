using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class MeasurementSet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}
