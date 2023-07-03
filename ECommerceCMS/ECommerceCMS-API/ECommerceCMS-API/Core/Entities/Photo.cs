namespace ECommerceCMS_API.Core.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public Product Product { get; set; } = new Product();
        public int ProductId { get; set; }
    }
}
