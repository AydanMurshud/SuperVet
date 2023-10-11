using Microsoft.EntityFrameworkCore;
using SuperVet.Models;

namespace SuperVet.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Pet> Pet { get; set; }
		public DbSet<Species> Species { get; set; }
		public DbSet<Breed> Breed { get; set; }
	}
}
