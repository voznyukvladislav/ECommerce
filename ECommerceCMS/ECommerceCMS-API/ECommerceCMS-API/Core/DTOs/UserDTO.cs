using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
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
        public int RoleId { get; set; }
        public string Reviews { get; set; }
        public string Orders { get; set; }
        public string ShoppingCarts { get; set; }
        public UserDTO()
        {

        }
        public UserDTO(User user)
        {
            this.Id = user.Id;
            this.Password = user.Password;
            this.Login = user.Login;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.Email = user.Email;
            this.Phone = user.Phone;
            this.RoleId = user.RoleId;
            this.Reviews = String.Join(", ", user.Reviews.Select(r => r.Id));
            this.Orders = String.Join(", ", user.Orders.Select(o => o.Id));
            this.ShoppingCarts = String.Join(", ", user.ShoppingCarts.Select(sc => sc.Id));
        }
    }
}
