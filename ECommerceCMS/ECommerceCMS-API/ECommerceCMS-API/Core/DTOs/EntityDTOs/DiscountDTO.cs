using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class DiscountDTO
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Products { get; set; }
        public DiscountDTO() { }
        public DiscountDTO(Discount discount)
        {
            Id = discount.Id;
            Value = discount.Value;
            if (discount.Products.Count != 0)
                Products = string.Join(", ", discount.Products.Select(p => p.Id));
        }
    }
}
