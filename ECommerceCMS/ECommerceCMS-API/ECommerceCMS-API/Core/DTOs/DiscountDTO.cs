using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class DiscountDTO
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Products { get; set; }
        public DiscountDTO() { }
        public DiscountDTO(Discount discount)
        {
            this.Id = discount.Id;
            this.Value = discount.Value;
            this.Products = String.Join(", ", discount.Products.Select(p => p.Id));
        }
    }
}
