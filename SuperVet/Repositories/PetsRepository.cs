using Microsoft.EntityFrameworkCore;
using SuperVet.Data;
using SuperVet.Interfaces;
using SuperVet.Models;

namespace SuperVet.Services
{
	public class PetsRepository : IPetsRepository
	{
		private readonly ApplicationDbContext _context;
		public PetsRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Pet>> GetAll()
		{
			return await _context.Pet.Include(s => s.Species).ToListAsync();
		}
		public async Task<Pet> GetById(int Id)
		{
			return await _context.Pet.Include(p => p.Species).FirstOrDefaultAsync(p => p.Id == Id);
		}
		public bool Add(Pet pets)
		{
			_context.Add(pets);
			return Save();
		}
		public bool Delete(Pet pets)
		{
			_context.Remove(pets);
			return Save();
		}
		public bool Update(Pet pets)
		{
			_context.Update(pets);
			return Save();
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

	}
}
