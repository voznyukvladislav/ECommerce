using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public int ProductId { get; set; }
        public PhotoDTO()
        {

        }
        public PhotoDTO(Photo photo)
        {
            this.Id = photo.Id;
            this.Source = photo.Source;
            this.ProductId = photo.ProductId;
        }
    }
}
