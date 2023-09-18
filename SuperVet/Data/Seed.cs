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
				if (!context.Pets.Any())
				{
					context.Pets.AddRange(new List<Pets>()
					{
						new Pets()
						{
							AnimalType="Mammal",

							Description = "Mammals are distinguished from other vertebrate animals by several unique features. " +
							"All mammals produce and secrete milk from mammary glands to feed their offspring. " +
							"They also have hair on their bodies, although some mammalian groups have less hair than others.",
							Image="https://upload.wikimedia.org/wikipedia/commons/0/0c/Cow_female_black_white.jpg",
							Species=new List<Species>()
							{
								 new Species()
								{
									Name="Canis",
									Description="A dog is a domestic mammal of the family Canidae and the order Carnivora. Its scientific name is Canis lupus familiaris.",
									Image="https://www.cesarsway.com/wp-content/uploads/2015/06/dog-breeds.png",
									Breeds = new List<Breeds>
									{
										new Breeds()
										{
										   Name = "German Shepherd",
										   Description="Strong and loyal" +
										   "Generally considered dogkind's finest all-purpose worker, " +
										   "the German Shepherd Dog is a large, agile, " +
										   "muscular dog of noble character and high intelligence. " +
										   "Loyal, confident, courageous, and steady, the German Shepherd is truly a dog lover's delight.",
										   Image="https://www.akc.org/wp-content/uploads/2017/11/German-Shepherd-on-White-00.jpg"
										},
										new Breeds()
										{
											Name  ="Doberman Pinscher",
											Description = "Strong and loyal" +
											"The Doberman pinscher has a long head and a sleek, muscular body. " +
											"The ears are often cropped to stand erect, and the tail is usually docked short. " +
											"The Doberman pinscher has a short, sleek and shiny coat that is black, dark red, blue or fawn with rust-colored markings on the face, body and tail.",
											Image="https://dogtime.com/wp-content/uploads/sites/12/2011/01/GettyImages-474330006-e1691273994614.jpg"
										},
										new Breeds()
										{
											Name="Chihuahua",
											Description="Small, but evil" +
											"The Chihuahua is a balanced, graceful dog of terrier-like demeanor, " +
											"weighing no more than 6 pounds. The rounded \"apple\" head is a breed hallmark. " +
											"The erect ears and full, luminous eyes are acutely expressive. Coats come in many colors and patterns, and can be long or short.",
											Image="https://www.akc.org/wp-content/uploads/2017/11/Chihuahua-standing-in-three-quarter-view.jpg"

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