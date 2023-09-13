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
                            AnimalType="Mammal",
                            Species=new List<Species>()
                            {
                                 new Species()
                                {
                                    Name="Kannel",
                                    Breeds = new List<Breeds>
                                    {
                                        new Breeds()
                                        {
                                           Name = "German Shepherd",
                                           Description="Strong and loyal"
                                        },
                                        new Breeds()
                                        {
                                            Name  ="Doberman Pinscher",
                                            Description = "Strong and loyal"
                                        },
                                        new Breeds()
                                        {
                                            Name="Chihuahua",
                                            Description="Small, but deadly"

                                        }

                                    }
                                }
                            }
                           
                        }

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}