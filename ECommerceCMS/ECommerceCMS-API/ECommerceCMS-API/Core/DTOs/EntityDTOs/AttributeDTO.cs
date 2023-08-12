using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class AttributeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsFilter { get; set; }
        public string MeasurementSetId { get; set; }
        public string AttributeSets { get; set; }
        public AttributeDTO()
        { }
        public AttributeDTO(Entities.Attribute attribute)
        {
            Id = attribute.Id;
            Name = attribute.Name;
            IsFilter = attribute.IsFilter.ToString();
            MeasurementSetId = attribute.MeasurementSetId.ToString();
            if (attribute.Attribute_AttributeSet.Count != 0)
                AttributeSets = string.Join(", ", attribute.Attribute_AttributeSet.Select(a_as => a_as.AttributeSetId));
        }
    }
}
