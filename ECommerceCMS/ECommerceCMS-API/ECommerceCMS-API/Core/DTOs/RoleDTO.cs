using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Users { get; set; }
        public RoleDTO()
        {

        }
        public RoleDTO(Role role)
        {
            this.Id = role.Id;
            this.Name = role.Name;
            this.Users = String.Join(", ", role.Users.Select(u => u.Id));
        }
    }
}
