using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public int RoleId { get; set; }
        public string Reviews { get; set; }
        public string Orders { get; set; }
        public string ShoppingCarts { get; set; }
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
