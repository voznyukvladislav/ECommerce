using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    [Index(nameof(Login), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;

        public Role Role { get; set; }
        public int RoleId { get; set; }

        public List<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

        public List<Order>? Orders { get; set; }
        public List<Review>? Reviews { get; set; }

        public User() { }
    }
}
