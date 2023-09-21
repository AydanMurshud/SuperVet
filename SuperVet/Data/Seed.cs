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
							Description="adsddnajdniajsndinasd",
							Image = "https://upload.wikimedia.org/wikipedia/commons/0/0c/Cow_female_black_white.jpg",
							Species = new List<Species>()
							{
								new Species()
								{
									Name="Canis",
									Description = "KSDAISD",
									Image="https://www.akc.org/wp-content/uploads/2018/05/Three-Australian-Shepherd-puppies-sitting-in-a-field.jpg",
									Breeds = new List<Breeds>()
									{
										new Breeds()
										{
											Name="German Shepherd",
											Description="Sdsdsdasfafasd",
											Image = "https://www.akc.org/wp-content/uploads/2017/11/German-Shepherd-on-White-00.jpg"
										},
										new Breeds()
										{
											Name="Pitbull",
											Description="Sdsdsdasfafasd",
											Image = "https://media.istockphoto.com/id/513392620/photo/big-dog.jpg?s=612x612&w=0&k=20&c=YgiuJ9_3LGYwHB40IVMnjwv8p-4RCFLwcD-yJAOYAGE="
										}
									}
								},
								new Species()
								{
									Name = "Feline",
									Description = "Dsadadamisdams,d';",
									Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTRnsczNMv69XUuip7z_1_KaTI564ZSRCGnzm_S_KCLbfwDHNzmoKCKtCPXusIaRvA7ZJ8&usqp=CAU",
									Breeds = new List<Breeds>()
									{
										new Breeds()
										{
											Name="American Bobtail Cat Breed",
											Description="Sdsdsdasfafasd",
											Image = "https://www.dailypaws.com/thmb/BlBOz9SUy9dr9Oc4mAXRD3dK0y8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/orange-american-bobtail-kitten-808979798-2000-64652e937de14c0e850ea9e900893d84.jpg"
										},
										new Breeds()
										{
											Name="Bengal",
											Description="Sdsdsdasfafasd",
											Image = "https://visitseaquest.com/wp-content/uploads/2022/11/unnamed-4.jpg"
										}
									}
								}
							}

						},
						new Pets()
						{
							AnimalType = "Reptiles",
							Description = "DJSHDAJHSJDAI",
							Image = "https://i.natgeofe.com/k/c02b35d2-bfd7-4ed9-aad4-8e25627cd481/komodo-dragon-head-on_16x9.jpg?w=1200",
							Species = new List<Species>()
							{
								new Species()
								{
									Name="lizards",
									Description="sadasasgea",
									Image = "https://i0.wp.com/post.healthline.com/wp-content/uploads/2021/06/lizard-iguana-1296x728-header.jpg?w=1155&h=15",
									Breeds = new List<Breeds>()
									{
										new Breeds()
										{
											Name="Jacsons Chameleon",
											Description="Sdsdsdasfafasd",
											Image = "https://assets.petco.com/petco/image/upload/f_auto,q_auto/jacksons-chameleon-care-sheet-hero"
										},
										new Breeds()
										{
											Name="Tokay Gecko",
											Description="Sdsdsdasfafasd",
											Image = "https://www.australiangeographic.com.au/wp-content/uploads/2021/11/EBN3D4-scaled.jpg"
										}
									}
								},
								new Species()
								{
									Name = "Snakes",
									Description="DASDAsdsads",
									Image = "https://res.cloudinary.com/dk-find-out/image/upload/q_80,w_1920,f_auto/DCTM_Penguin_UK_DK_AL707430_tjxppv.jpg",
									Breeds = new List<Breeds>()
									{
										new Breeds()
										{
											Name="King Cobra",
											Description="Sdsdsdasfafasd",
											Image = "https://i0.wp.com/virginiazoo.org/wp-content/uploads/2020/12/GettyImages-1281306013.jpg?fit=2119%2C1415&ssl=1"
										},
										new Breeds()
										{
											Name="Rattle snake",
											Description="Sdsdsdasfafasd",
											Image = "https://cloudfront-us-east-2.images.arcpublishing.com/reuters/EPLX6XS5WZNG7P25EQQQHAR3ZY.jpg"
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