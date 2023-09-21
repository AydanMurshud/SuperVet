using Microsoft.EntityFrameworkCore;
using SuperVet.Data;
using SuperVet.Interfaces;
using SuperVet.Models;

namespace SuperVet.Services
{
	public class BreedsService : IBreedsServices
	{
		private readonly ApplicationDbContext _context;

		public BreedsService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Breeds>> GetAllBreeds()
		{
			return await _context.Breeds.ToListAsync();
		}
		public async Task<Breeds> GetBreedById(int Id)
		{
			return await _context.Breeds.FirstOrDefaultAsync(b => b.Id == Id);
		}
		public async Task<IEnumerable<Breeds>> GetBreedBySpeciesId(int SpeciesId)
		{
			return await _context.Breeds.Where(b=>b.SpeciesId==SpeciesId).ToListAsync();
		}
		public bool Add(Breeds breeds)
		{
			_context.Add(breeds);
			return Save();
		}

		public bool Update(Breeds breeds)
		{
			_context.Update(breeds);
			return Save();
		}
		public bool Delete(Breeds breeds)
		{
			_context.Remove(breeds);
			return Save();
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

	}
}
