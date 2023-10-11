
using Microsoft.AspNetCore.Mvc;
using SuperVet.Interfaces;
using SuperVet.Models;
using SuperVet.ViewModels;

namespace SuperVet.Controllers
{
	public class BreedsController : Controller
	{
		private readonly IBreedsRepository _breedsServices;
		private readonly ISpeciesRepository _speciesServices;
		private readonly IPetsRepository _petsServices;
		public BreedsController(IBreedsRepository breedsServices, ISpeciesRepository speciesServices, IPetsRepository petsServices)
		{
			_petsServices = petsServices;
			_speciesServices = speciesServices;
			_breedsServices = breedsServices;
		}
		public async Task<IActionResult> Index(int SpeciesId)
		{
			var breeds = await _breedsServices.GetBreedBySpeciesId(SpeciesId);
			return View(breeds);
		}
		public async Task<IActionResult> Details(int BreedId)
		{
			var breed = await _breedsServices.GetById(BreedId);
			return View(breed);
		}
		public async Task<IActionResult> Create()
		{
			var pets = await _petsServices.GetAll();
			var species = await _speciesServices.GetAll();
			var breedVM = new BreedViewModel()
			{
				Name = "",
				Description = "",
				Image = "",
				Species = species.ToList(),
				Pets = pets.ToList(),
			};
			return View(breedVM);
		}
		[HttpPost]
		public IActionResult Create(BreedViewModel breedVM)
		{
			if (!ModelState.IsValid)
			{
				return View(breedVM);
			}
			var breed = new Breed
			{
				Name = breedVM.Name,
				Description = breedVM.Description,
				Image = breedVM.Image,
				SpeciesId = breedVM.SpeciesId,
				PetId = breedVM.PetId
			};
			_breedsServices.Add(breed);
			return RedirectToAction("Index", new { SpeciesId = breed.SpeciesId });
		}
		public async Task<IActionResult> Edit(int Id)
		{
			var pets = await _petsServices.GetAll();
			var species = await _speciesServices.GetAll();
			var breed = await _breedsServices.GetById(Id);
			if (breed == null) return View("Error");
			var breedVM = new BreedViewModel()
			{
				Name = breed.Name,
				Description = breed.Description,
				Image = breed.Image,
				SpeciesId = breed.SpeciesId,
				Species = species.ToList(),
				PetId = breed.PetId,
				Pets = pets.ToList()
			};
			return View(breedVM);
		}
		[HttpPost]
		public IActionResult Edit(int Id, BreedViewModel breedVM)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Failed to edit breed");
				return View("Edit", breedVM);
			}
			var breed = new Breed
			{
				Id = Id,
				Name = breedVM.Name,
				Description = breedVM.Description,
				Image = breedVM.Image,
				SpeciesId = breedVM.SpeciesId,
				PetId = breedVM.PetId
			};
			_breedsServices.Update(breed);
			return RedirectToAction("Index", new { SpeciesId = breed.SpeciesId });
		}
		public async Task<IActionResult> Delete(int Id)
		{
			var breed = await _breedsServices.GetById(Id);
			if (breed == null) return View("Error");
			return View(breed);
		}
		[HttpPost, ActionName("DeleteBreed")]

		public async Task<IActionResult> DeleteBreed(int Id)
		{
			var breed = await _breedsServices.GetById(Id);
			if (breed == null) return View("Error");
			_breedsServices.Delete(breed);
			return RedirectToAction("Index", new { SpeciesId = breed.SpeciesId });
		}
	}
}
