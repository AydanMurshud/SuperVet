
using Microsoft.AspNetCore.Mvc;
using SuperVet.Data;
using SuperVet.Interfaces;
using SuperVet.Models;
using SuperVet.ViewModels;

namespace SuperVet.Controllers
{
	public class BreedsController : Controller
	{
		private readonly IBreedsServices _breedsServices;
		private readonly ISpeciesServices _speciesServices;
		private readonly IPetsServices _petsServices;
		public BreedsController(IBreedsServices breedsServices,ISpeciesServices speciesServices, IPetsServices petsServices)
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
		public async Task<IActionResult> Create()
		{
			var pets = await _petsServices.GetAllPets();
			var species = await _speciesServices.GetAllSpecies();
			var breedVM = new BreedViewModel()
			{
				Name = "",
				Description = "",
				Image = "",
				Species = species.ToList(),
				Pets =  pets.ToList(),
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
			var breed = new Breeds
			{
				Name=breedVM.Name,
				Description=breedVM.Description,
				Image = breedVM.Image,
				SpeciesId = breedVM.SpeciesId,
				PetsId = breedVM.PetsId
			};
			_breedsServices.Add(breed);
			return RedirectToAction("Index", new {SpeciesId = breed.SpeciesId});
		}		
		public async Task<IActionResult> Edit(int Id)
		{
			var pets = await _petsServices.GetAllPets();
			var species = await _speciesServices.GetAllSpecies();
			var breed = await _breedsServices.GetBreedById(Id);
			if (breed == null) return View("Error");
			var breedVM = new BreedViewModel()
			{
				Name = breed.Name,
				Description = breed.Description,
				Image = breed.Image,
				SpeciesId = breed.SpeciesId,
				Species = species.ToList(),
				PetsId = breed.PetsId,
				Pets=pets.ToList()
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
			var breed = new Breeds
			{
				Id = Id,
				Name = breedVM.Name,
				Description = breedVM.Description,
				Image = breedVM.Image,
				SpeciesId = breedVM.SpeciesId,
				PetsId = breedVM.PetsId
			};
			_breedsServices.Update(breed);
			return RedirectToAction("Index", new { SpeciesId = breed.SpeciesId });
		}
		public async Task<IActionResult> Delete(int Id)
		{
			var breed = await _breedsServices.GetBreedById(Id);
			if (breed == null) return View("Error");
			return View(breed);
		}
		[HttpPost, ActionName("DeleteBreed")]

		public async Task<IActionResult> DeleteBreed(int Id)
		{
			var breed = await _breedsServices.GetBreedById(Id);
			if (breed == null) return View("Error");
			_breedsServices.Delete(breed);
			return RedirectToAction("Index", new { SpeciesId = breed.SpeciesId });
		}
	}
}
