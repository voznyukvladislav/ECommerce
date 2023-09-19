using Bogus;
using ECommerceCMS_API.Core.Entities;

namespace ECommerceApp_API.Infrastructure.Data
{
    public class DataGenerator
    {
        public static User GenerateUser(ECommerceDbContext db)
        {
            Role userRole = db.Roles.Where(r => r.Name == "User").First();

            Faker<User> faker = new Faker<User>();
            faker.RuleFor(u => u.Name, f => f.Name.FirstName())
                .RuleFor(u => u.Surname, f => f.Name.LastName())
                .RuleFor(u => u.Login, (f, u) => f.Internet.UserName(u.Surname, u.Name))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name, u.Surname))
                .RuleFor(u => u.Role, f => userRole)
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.RoleId, f => userRole.Id)
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber());

            return faker.Generate();
        }

        public static List<User> GenerateUsers(ECommerceDbContext db)
        {
            List<User> users = new();
            for (int i = 0; i < new Random().Next(1, 20); i++)
            {
                users.Add(GenerateUser(db));
            }

            return users;
        }

        public static Review GenerateReview(User user, Product product)
        {
            Faker<Review> faker = new Faker<Review>();
            faker
                .RuleFor(r => r.User, f => user)
                .RuleFor(r => r.UserId, f => user.Id)
                .RuleFor(r => r.Product, f => product)
                .RuleFor(r => r.ProductId, f => product.Id)
                .RuleFor(r => r.Rating, f => new Random().Next(1, 6))
                .RuleFor(r => r.Text, f => f.Lorem.Text())
                .RuleFor(r => r.ReviewDate, f => f.Date.Between(DateTime.MinValue, DateTime.Now));

            return faker.Generate();
        }
    }
}
