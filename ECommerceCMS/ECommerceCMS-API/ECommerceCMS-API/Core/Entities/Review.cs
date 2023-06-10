using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
