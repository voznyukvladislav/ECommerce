using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Core.DTOs
{
    public class UserInfoDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public UserInfoDTO(User user)
        {
            this.Name = user.Name is null ? "" : user.Name;
            this.Surname = user.Surname is null ? "" : user.Surname;
            this.Email = user.Email;
            this.Login = user.Login;
            this.Phone = user.Phone is null ? "" : user.Phone;
            this.Role = user.Role.Name;
        }
    }
}
