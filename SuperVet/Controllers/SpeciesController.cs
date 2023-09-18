using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperVet.Data;

namespace SuperVet.Controllers
{
	public class SpeciesController : Controller
	{
		private readonly ApplicationDbContext _context;
		public SpeciesController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var species = _context.Species.Include(s=>s.Breeds);
			return View(species);
		}
		public IActionResult Breeds(int Id)
		{
			var breed = _context.Breeds.FirstOrDefault(b => b.Id == Id);
			return View(breed);
		}
	}
}
