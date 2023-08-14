using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string Source { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public PhotoDTO()
        {

        }
        public PhotoDTO(Photo photo)
        {
            Id = photo.Id;
            Source = photo.Source;
            ProductId = photo.ProductId;
        }
    }
}
