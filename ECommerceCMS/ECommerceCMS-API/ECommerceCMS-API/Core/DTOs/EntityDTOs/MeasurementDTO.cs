using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class MeasurementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MeasurementSets { get; set; }
        public MeasurementDTO()
        {

        }
        public MeasurementDTO(Measurement measurement)
        {
            Id = measurement.Id;
            Name = measurement.Name;
            if (measurement.MeasurementSets.Count != 0)
                MeasurementSets = string.Join(", ", measurement.MeasurementSets.Select(ms => ms.Id));
        }
    }
}
