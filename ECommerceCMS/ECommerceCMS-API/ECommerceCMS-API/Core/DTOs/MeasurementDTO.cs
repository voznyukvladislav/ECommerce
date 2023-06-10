using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class MeasurementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MeasurementSets { get; set; }
        public string Attributes { get; set; }
        public MeasurementDTO()
        {

        }
        public MeasurementDTO(Measurement measurement)
        {
            this.Id = measurement.Id;
            this.Name = measurement.Name;
            this.MeasurementSets = String.Join(", ", measurement.MeasurementSets.Select(ms => ms.Id));
            this.Attributes = String.Join(", ", measurement.Attributes.Select(a => a.Id));
        }
    }
}
