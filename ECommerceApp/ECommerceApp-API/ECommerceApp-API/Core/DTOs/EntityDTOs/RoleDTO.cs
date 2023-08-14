using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs.EntityDTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Users { get; set; } = string.Empty;
        public RoleDTO()
        {

        }
        public RoleDTO(Role role)
        {
            Id = role.Id;
            Name = role.Name;
            if (role.Users.Count != 0)
                Users = string.Join(", ", role.Users.Select(u => u.Id));
        }
    }
}
