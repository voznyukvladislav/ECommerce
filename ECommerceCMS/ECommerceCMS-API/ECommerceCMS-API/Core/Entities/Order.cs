using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
