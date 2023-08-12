using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class AttributeSetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Attributes { get; set; }
        public string Templates { get; set; }
        public AttributeSetDTO()
        { }
        public AttributeSetDTO(AttributeSet attributeSet)
        {
            Id = attributeSet.Id;
            Name = attributeSet.Name;
            if (attributeSet.Attribute_AttributeSet.Count != 0)
                Attributes = string.Join(", ", attributeSet.Attribute_AttributeSet.Select(a => a.AttributeId));
            if (attributeSet.Templates.Count != 0)
                Templates = string.Join(", ", attributeSet.Templates.Select(t => t.Id));
        }
    }
}
