using Microsoft.EntityFrameworkCore;
using SuperVet.Data;
using SuperVet.Interfaces;
using SuperVet.Models;

namespace SuperVet.Services
{
	public class SpeciesService : ISpeciesServices
	{
		private readonly ApplicationDbContext _context;

		public SpeciesService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Species>> GetAllSpecies()
		{
			return await _context.Species.ToListAsync();
		}
		public async Task<Species> GetSpeciesById(int Id)
		{
			return await _context.Species.Include(s => s.Breeds).FirstOrDefaultAsync(s => s.Id == Id);
		}
		public async Task<IEnumerable<Species>> GetSpeciesByPetId(int PetsId)
		{
			return await _context.Species.Include(s => s.Breeds).Where(s => s.PetsId == PetsId).ToListAsync();
		}
		public bool Add(Species species)
		{
			_context.Add(species);
			return Save();
		}
		public bool Update(Species species)
		{
			_context.Update(species);
			return Save();
		}
		public bool Delete(Species species)
		{
			_context.Remove(species);
			return Save();
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
	}
}
