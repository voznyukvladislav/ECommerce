using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }

        public List<ShoppingCart> ShoppingCarts { get; set; }

        public List<Order> Orders { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
