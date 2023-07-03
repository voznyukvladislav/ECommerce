using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class MeasurementSetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Measurements { get; set; }
        public MeasurementSetDTO()
        {

        }
        public MeasurementSetDTO(MeasurementSet measurementSet)
        {
            this.Id = measurementSet.Id;
            this.Name = measurementSet.Name;
            if(measurementSet.Measurements.Count != 0)
                this.Measurements = String.Join(", ", measurementSet.Measurements.Select(m => m.Id));
        }
    }
}
