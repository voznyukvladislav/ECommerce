using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class TemplateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AttributeSets { get; set; }
        public string Products { get; set; }
        public TemplateDTO()
        {

        }
        public TemplateDTO(Template template)
        {
            this.Id = template.Id;
            this.Name = template.Name;
            this.AttributeSets = String.Join(", ", template.AttributeSets.Select(a => a.Id));
            this.Products = String.Join(", ", template.Products.Select(p => p.Id));
        }
    }
}
