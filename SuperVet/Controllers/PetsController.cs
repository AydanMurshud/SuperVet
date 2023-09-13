using Microsoft.AspNetCore.Mvc;
using SuperVet.Data;
using SuperVet.Models;

namespace SuperVet.Controllers
{
    public class PetsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PetsController(ApplicationDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            List<Pets> pets = _context.Pets.ToList();
            return View(pets);
        }
    }
}
