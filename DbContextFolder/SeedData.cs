using Ecommerce.DbContextFolder;
using Ecommerce.Interface.Repositories;
using Ecommerce.Models.Entities;
using Ecommerce.Models.Enums;

namespace Ecommerce;

public class SeedData
{
    public static void SeedUsers(ApplicationDbContext dbContext)
    {
        if (!dbContext.Users.Any(u => u.Email == "admin@gmail.com"))
        {
            var adminUser = new User
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("superAdmin123"), // Hash the password
                Role = Role.SuperAdmin,
            };
            var profile = new Profile
            {
                FirstName = "Admin",
                LastName = "Admin",
                PhoneNumber = "08161778965",
                Gender = Gender.Female,
                Address = "oluwole street, abeokuta, ogun state",
                UserId = adminUser.Id,
                User = adminUser,
            };
            dbContext.Users.Add(adminUser);
            dbContext.Profiles.Add(profile);
            dbContext.SaveChanges();
            
        }
    }
}
public static class SeedDataExtensions
{
    public static IApplicationBuilder UseSeedData(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedData.SeedUsers(dbContext);
        }

        return app;
    }
}