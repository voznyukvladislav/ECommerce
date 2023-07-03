using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class AttributeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MeasurementSetId { get; set; }
        public string AttributeSets { get; set; }
        public AttributeDTO()
        { }
        public AttributeDTO(Entities.Attribute attribute)
        {
            this.Id = attribute.Id;
            this.Name = attribute.Name;
            this.MeasurementSetId = attribute.MeasurementSetId.ToString();
            if (attribute.Attribute_AttributeSet.Count != 0)
                this.AttributeSets = String.Join(", ", attribute.Attribute_AttributeSet.Select(a_as => a_as.AttributeSetId));
        }
    }
}
