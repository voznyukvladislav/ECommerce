using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class ShoppingCartDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Products { get; set; }
        public ShoppingCartDTO()
        {

        }
        public ShoppingCartDTO(ShoppingCart shoppingCart)
        {
            Id = shoppingCart.Id;
            UserId = shoppingCart.UserId;
            if (shoppingCart.Products.Count != 0)
                Products = string.Join(", ", shoppingCart.Products.Select(p => p.Id));
        }
    }
}
