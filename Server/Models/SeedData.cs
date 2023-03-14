using Microsoft.AspNetCore.Identity;
using StudentTrackerSystem.Server.Data;

namespace StudentTrackerSystem.Server.Models
{
    public class SeedData
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            ApplicationDbContext context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // Ensure the Identity tables exist
            await context.Database.EnsureCreatedAsync();

            List<IdentityRole> createRoles = new List<IdentityRole>()
            {
                new IdentityRole("Administrator"),
                new IdentityRole("Student")
            };

            foreach (var role in createRoles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                    await roleManager.CreateAsync(role);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}

