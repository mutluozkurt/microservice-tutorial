using PlatformService.Models;

namespace PlatformService.Data
{
    public class PreperDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var servicesScope = app.ApplicationServices.CreateScope())
            {
                SeedData(servicesScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                    new Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="SQL Servre Express", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="Kuburnetes", Publisher="Cloud Native Computing Foundation", Cost="Free"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data.");
            }
        }
    }
}