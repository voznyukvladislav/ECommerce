using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
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
            this.Id = attributeSet.Id;
            this.Name = attributeSet.Name;
            this.Attributes = String.Join(", ", attributeSet.Attributes.Select(a => a.Id));
            this.Templates = String.Join(", ", attributeSet.Templates.Select(t => t.Id));
        }
    }
}
