using Microsoft.AspNetCore.Mvc;
using SuperVet.Data;
using SuperVet.Interfaces;
using SuperVet.Models;
using SuperVet.Services;

namespace SuperVet.Controllers
{
	public class BreedsController : Controller
	{
		private readonly IBreedsServices _breedsServices;
		public BreedsController(IBreedsServices breedsServices)
		{
			_breedsServices = breedsServices;
		}
		public async Task<IActionResult> Index(int SpeciesId)
		{
			var breeds = await _breedsServices.GetBreedBySpeciesId(SpeciesId);
			return View(breeds);
		}
	}
}
