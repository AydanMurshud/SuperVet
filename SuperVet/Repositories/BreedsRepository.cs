using Microsoft.EntityFrameworkCore;
using SuperVet.Data;
using SuperVet.Interfaces;
using SuperVet.Models;

namespace SuperVet.Services
{
	public class BreedsRepository : IBreedsRepository
	{
		private readonly ApplicationDbContext _context;
		public BreedsRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Breed>> GetAll()
		{
			return await _context.Breed.ToListAsync();
		}
		public async Task<Breed> GetById(int Id)
		{
			return await _context.Breed.FirstAsync(b => b.Id == Id);
		}
		public async Task<IEnumerable<Breed>> GetBreedBySpeciesId(int SpeciesId)
		{
			return await _context.Breed.Where(b => b.SpeciesId == SpeciesId).ToListAsync();
		}
		public bool Add(Breed breeds)
		{
			_context.Add(breeds);
			return Save();
		}
		public bool Update(Breed breeds)
		{
			_context.Update(breeds);
			return Save();
		}
		public bool Delete(Breed breeds)
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