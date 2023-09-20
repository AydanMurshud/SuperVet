using Microsoft.AspNetCore.Mvc;
using SuperVet.Data;
using SuperVet.Models;

namespace SuperVet.Controllers
{
	public class BreedsController : Controller
	{
		private readonly ApplicationDbContext _context;
		public BreedsController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Breed(int Id)
		{	
			var breed = _context.Breeds.FirstOrDefault(b => b.Id == Id);
			
			return View(breed);
		}
	}
}
