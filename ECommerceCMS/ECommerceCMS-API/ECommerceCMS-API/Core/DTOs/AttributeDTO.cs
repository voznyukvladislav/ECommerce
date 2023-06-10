using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class AttributeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MeasurementId { get; set; }
        public string AttributeSets { get; set; }
        public AttributeDTO()
        { }
        public AttributeDTO(Entities.Attribute attribute)
        {
            this.Id = attribute.Id;
            this.Name = attribute.Name;
            this.MeasurementId = attribute.MeasurementId;
            this.AttributeSets = String.Join(", ", attribute.AttributeSets.Select(a => a.Id));
        }
    }
}
