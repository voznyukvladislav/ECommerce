using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class MeasurementSetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Measurements { get; set; } = string.Empty;
        public MeasurementSetDTO() { }
        public MeasurementSetDTO(MeasurementSet measurementSet)
        {
            Id = measurementSet.Id;
            Name = measurementSet.Name;
            if (measurementSet.Measurements.Count != 0)
                Measurements = string.Join(", ", measurementSet.Measurements.Select(m => m.Id));
        }
    }
}
