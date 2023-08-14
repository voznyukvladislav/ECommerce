using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class TemplateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AttributeSets { get; set; } = string.Empty;
        public string Products { get; set; } = string.Empty;
        public TemplateDTO()
        {

        }
        public TemplateDTO(Template template)
        {
            Id = template.Id;
            Name = template.Name;
            if (template.AttributeSets.Count != 0)
                AttributeSets = string.Join(", ", template.AttributeSets.Select(a => a.Id));
            if (template.Products.Count != 0)
                Products = string.Join(", ", template.Products.Select(p => p.Id));
        }
    }
}
