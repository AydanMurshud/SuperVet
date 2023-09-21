using Microsoft.EntityFrameworkCore;
using SuperVet.Data;
using SuperVet.Interfaces;
using SuperVet.Models;

namespace SuperVet.Services
{
	public class PetsService : IPetsServices
	{
		private readonly ApplicationDbContext _context;
		public PetsService(ApplicationDbContext context)
		{
			_context = context;
		}

		public bool Add(Pets pets)
		{
			_context.Add(pets);
			return Save();
		}
		public bool Delete(Pets pets)
		{
			_context.Remove(pets);
			return Save();
		}
		public async Task<IEnumerable<Pets>> GetAllPets()
		{
			return await _context.Pets.Include(s=>s.Species).ToListAsync();
		}
		public async Task<Pets> GetPetById(int Id)
		{
			return await _context.Pets.Include(p=>p.Species).FirstOrDefaultAsync(p => p.Id == Id);
		}
		public bool Update(Pets pets)
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
