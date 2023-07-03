using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
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
            this.Id = shoppingCart.Id;
            this.UserId = shoppingCart.UserId;
            if(shoppingCart.Products.Count != 0)
                this.Products = String.Join(", ", shoppingCart.Products.Select(p => p.Id));
        }
    }
}
