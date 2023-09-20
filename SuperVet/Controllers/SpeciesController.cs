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
			var species = _context.Species.Include(b => b.Breeds).ToList();
			return View(species);
		}

		public IActionResult Breeds(int Id)
		{
			var breeds = _context.Species.Include(b => b.Breeds).FirstOrDefault(s=>s.Id==Id);
			return View(breeds);
		}
	}
}
