using System.ComponentModel.DataAnnotations;
using System.Linq;
using static Azure.Core.HttpHeader;

namespace ECommerceCMS_API.Core.Entities
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<MeasurementSet> MeasurementSets { get; set; } = new List<MeasurementSet>();
        public List<Value> Values { get; set; } = new List<Value>();

        public Measurement() { }
    }
}
