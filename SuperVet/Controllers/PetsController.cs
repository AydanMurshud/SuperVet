using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperVet.Data;

namespace SuperVet.Controllers
{
	public class PetsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public PetsController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var pets = _context.Pets.Include(s=>s.Species).ToList();
			return View(pets);
		}

	}
}
