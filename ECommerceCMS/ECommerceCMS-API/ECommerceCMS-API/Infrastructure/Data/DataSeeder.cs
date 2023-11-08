using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Infrastructure.Data
{
    public class DataSeeder
    {
        public static void SeedRoles(ECommerceDbContext db)
        {
            Role admin = new Role() { Name = "Admin" };
            Role user = new Role() { Name = "User" };

            db.Roles.Add(admin);
            db.Roles.Add(user);

            db.SaveChanges();
        }

        public static void SeedUsers(ECommerceDbContext db) {
            User admin = new User()
            {
                Email = "admin@mail.com",
                Name = "Admin",
                Surname = "Adi",
                Login = "Admin",
                Role = db.Roles.Where(r => r.Name == "Admin").First(),
                Password = "123321",
                Phone = "0000000000",
                RoleId = db.Roles.Where(r => r.Name == "Admin").Select(r => r.Id).First()
            };

            admin.ShoppingCarts = new List<ShoppingCart>
            {
                new ShoppingCart() { User = admin }
            };

            db.SaveChanges();
        }

        public static void SeedOrderStatuses(ECommerceDbContext db)
        {
            db.OrderStatuses.Add(new OrderStatus() { Status = "Registered" });
            db.OrderStatuses.Add(new OrderStatus() { Status = "Sent" });
            db.OrderStatuses.Add(new OrderStatus() { Status = "Received" });

            db.SaveChanges();
        }

        public static void SeedDiscounts(ECommerceDbContext db) {
            db.Discounts.Add(new Discount() { Value = 0 });

            db.SaveChanges();
        }
    }
}
