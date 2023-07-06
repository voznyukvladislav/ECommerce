using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
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

        public List<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

        public List<Order>? Orders { get; set; }
        public List<Review>? Reviews { get; set; }

        public User() { }
        public User(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();
            if (nameValue.ContainsKey("User.Id"))
                this.Id = Int32.Parse(nameValue["User.Id"]);
            this.Name = nameValue["User.Name"];
            this.Surname = nameValue["User.Surname"];
            this.Login = nameValue["User.Login"];
            this.Password = nameValue["User.Password"];
            this.Email = nameValue["User.Email"];
            this.Phone = nameValue["User.Phone"];
            
            this.RoleId = Int32.Parse(nameValue["User.RoleId"]);
            this.Role = db.Roles.Where(r => r.Id == this.RoleId).First();
        }
    }
}
