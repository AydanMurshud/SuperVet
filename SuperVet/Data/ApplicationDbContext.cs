using Microsoft.EntityFrameworkCore;
using SuperVet.Models;

namespace SuperVet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Pets> Pets { get; set; }
    }
}
