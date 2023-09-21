using Microsoft.AspNetCore.Mvc;
using SuperVet.Interfaces;
using SuperVet.Models;
using SuperVet.ViewModels;

namespace SuperVet.Controllers
{
	public class PetsController : Controller
	{
		private readonly IPetsServices _petServices;

		public PetsController(IPetsServices petsServices)
		{

			_petServices = petsServices;

		}
		public async Task<IActionResult> Index()
		{
			var pets = await _petServices.GetAllPets();
			return View(pets);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreatePetsViewModel petVM)
		{
			if (!ModelState.IsValid)
			{
				return View(petVM);
			}
			var pet = new Pets
			{
				AnimalType = petVM.AnimalType,

				Description = petVM.Description,
				Image = petVM.Image,
			};
			_petServices.Add(pet);
			return RedirectToAction("Index");

		}
		public async Task<IActionResult> Edit(int Id)
		{
			var pet = await _petServices.GetPetById(Id);
			if (pet == null) return View("Error");
			var petVM = new EditPetsViewModel
			{
				AnimalType = pet.AnimalType,
				Description = pet.Description,
				Image = pet.Image,

			};
			return View(petVM);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int Id, EditPetsViewModel petVM)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Failed to edit Pet");
				return View("Edit", petVM);
			}
			var pet = new Pets
			{
				Id = Id,
				AnimalType = petVM.AnimalType,
				Description = petVM.Description,
				Image = petVM.Image,
			};
			_petServices.Update(pet);

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int Id)
		{
			var pet = await _petServices.GetPetById(Id);
			if(pet == null) return View("Error");
			return View(pet);
		}
		[HttpPost,ActionName("DeletePet")]
		public async Task<IActionResult> DeletePet(int Id)
		{
			var pet = await _petServices.GetPetById(Id);
			if (pet == null) return View("Error");
			_petServices.Delete(pet);
			return RedirectToAction("Index");
		}
	}
}
