using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();

        public Role() { }
        public Role(InputBlockDTO inputBlockDTO) {
            Dictionary<string, string> nameValues = inputBlockDTO.GetNameValueDictionary();
            if (nameValues.ContainsKey("Role.Id"))
                this.Id = Int32.Parse(nameValues["Role.Id"]);
            this.Name = nameValues["Role.Name"];
        }
    }
}
