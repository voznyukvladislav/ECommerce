﻿using ECommerceCMS_API.Core.Entities;

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
            if(user.Reviews is not null && user.Reviews?.Count != 0)
                this.Reviews = String.Join(", ", user.Reviews.Select(r => r.Id));
            if(user.Orders is not null && user.Orders?.Count != 0)
                this.Orders = String.Join(", ", user.Orders.Select(o => o.Id));
            if(user.ShoppingCarts.Count != 0)
                this.ShoppingCarts = String.Join(", ", user.ShoppingCarts.Select(sc => sc.Id));
        }
    }
}
