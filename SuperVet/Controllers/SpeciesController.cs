using Microsoft.AspNetCore.Mvc;
using SuperVet.Interfaces;

namespace SuperVet.Controllers
{
	public class SpeciesController : Controller
	{
		private readonly ISpeciesServices _speciesServices;
		public SpeciesController(ISpeciesServices speciesServices)
		{
			_speciesServices = speciesServices;
		}
		public async Task<IActionResult> Index(int PetsId)
		{
			var species = await _speciesServices.GetSpeciesByPetId(PetsId);
			return View(species);
		}

		//public async Task<IActionResult> Breeds(int Id)
		//{
		//	var breeds = await _speciesServices.GetSpeciesById(Id);
		//	return View(breeds);
		//}
	}
}
