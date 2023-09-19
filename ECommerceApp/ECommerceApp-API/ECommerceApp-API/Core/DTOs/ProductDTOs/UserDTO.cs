using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.DTOs.ProductDTOs
{
    public class UserDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public UserDTO()
        {

        }

        public UserDTO(User user)
        {
            this.Name = $"{user.Surname} {user.Name}";
            this.Login = user.Login;
            this.Email = user.Email;
        }
    }
}
