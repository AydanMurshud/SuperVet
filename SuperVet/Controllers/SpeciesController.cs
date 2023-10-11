using Microsoft.AspNetCore.Mvc;
using SuperVet.Interfaces;
using SuperVet.Models;
using SuperVet.ViewModels;

namespace SuperVet.Controllers
{
	public class SpeciesController : Controller
	{
		private readonly ISpeciesRepository _speciesServices;
		private readonly IPetsRepository _petsServices;
		public SpeciesController(ISpeciesRepository speciesServices, IPetsRepository petsServices)
		{
			_petsServices = petsServices;
			_speciesServices = speciesServices;
		}
		public async Task<IActionResult> Index(int PetsId)
		{
			var species = await _speciesServices.GetSpeciesByPetsId(PetsId);
			return View(species);
		}
		public async Task<IActionResult> Create()
		{
			var pets = await _petsServices.GetAll();
			var speciesVM = new SpeciesViewModel()
			{
				Name = "",
				Description = "",
				Image = "",
				Pets = pets.ToList(),

			};
			return View(speciesVM);
		}
		[HttpPost]
		public IActionResult Create(SpeciesViewModel speciesVM)
		{
			if (!ModelState.IsValid)
			{
				return View(speciesVM);
			}
			var species = new Species
			{
				Name = speciesVM.Name,
				Description = speciesVM.Description,
				Image = speciesVM.Image,
				PetId = speciesVM.PetId
			};
			_speciesServices.Add(species);
			return RedirectToAction("Index", new { PetsId = species.PetId });
		}
		public async Task<IActionResult> Edit(int Id)
		{
			var pets = await _petsServices.GetAll();
			var species = await _speciesServices.GetById(Id);
			if (species == null) return View("Error");
			var speciesVM = new SpeciesViewModel()
			{
				Name = species.Name,
				Description = species.Description,
				Image = species.Image,
				Pets = pets.ToList(),
				PetId = species.PetId
			};
			return View(speciesVM);
		}

		[HttpPost]
		public IActionResult Edit(int Id, SpeciesViewModel speciesVM)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Failed to edit Species");
				return View("Edit", speciesVM);
			}
			var species = new Species
			{
				Id = Id,
				Name = speciesVM.Name,
				Description = speciesVM.Description,
				Image = speciesVM.Image,
				PetId = speciesVM.PetId
			};
			_speciesServices.Update(species);

			return RedirectToAction("Index", new { PetsId = species.PetId });
		}
		public async Task<IActionResult> Delete(int Id)
		{
			var species = await _speciesServices.GetById(Id);
			if (species == null) return View("Error");
			return View(species);
		}
		[HttpPost, ActionName("DeleteSpecies")]

		public async Task<IActionResult> DeleteSpecies(int Id)
		{
			var species = await _speciesServices.GetById(Id);
			if (species == null) return View("Error");
			_speciesServices.Delete(species);
			return RedirectToAction("Index", new { PetsId = species.PetId });
		}
	}
}
