using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public decimal Value { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public Discount()
        {

        }
    }
}
