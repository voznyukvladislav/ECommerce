using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string Reviews { get; set; } = string.Empty;
        public string Orders { get; set; } = string.Empty;
        public string ShoppingCarts { get; set; } = string.Empty;
        public UserDTO()
        {

        }
        public UserDTO(User user)
        {
            Id = user.Id;
            Password = user.Password;
            Login = user.Login;
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            Phone = user.Phone;
            RoleId = user.RoleId;
            Role = user.Role.Name;
            if (user.Reviews is not null && user.Reviews?.Count != 0)
                Reviews = string.Join(", ", user.Reviews.Select(r => r.Id));
            if (user.Orders is not null && user.Orders?.Count != 0)
                Orders = string.Join(", ", user.Orders.Select(o => o.Id));
            if (user.ShoppingCarts.Count != 0)
                ShoppingCarts = string.Join(", ", user.ShoppingCarts.Select(sc => sc.Id));
        }
    }
}
