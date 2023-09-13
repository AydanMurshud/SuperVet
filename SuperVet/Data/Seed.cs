using SuperVet.Models;

namespace SuperVet.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if(!context.Pets.Any())
                {
                    context.Pets.AddRange(new List<Pets>()
                    {
                        new Pets()
                        {
                            Type = "Aquatic",
                            Species = "Fish",
                            Breed = "Guppies",
                            Description = "Descrption",
                            Picture = "https://cdn.britannica.com/02/117202-004-526214C9.jpg"
                        },
                        new Pets()
                        {
                            Type = "Mammal",
                            Species = "Dog",
                            Breed = "German Shepherd",
                            Description = "Descrption",
                            Picture = "https://cdn.britannica.com/79/232779-050-6B0411D7/German-Shepherd-dog-Alsatian.jpg"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
} 
