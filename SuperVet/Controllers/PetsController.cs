using Microsoft.AspNetCore.Mvc;
using SuperVet.Interfaces;
using SuperVet.Models;

namespace SuperVet.Controllers
{
	public class PetsController : Controller
	{
		private readonly IPetsRepository _petServices;

		public PetsController(IPetsRepository petsServices)
		{
			_petServices = petsServices;
		}
		public async Task<IActionResult> Index()
		{
			var pets = await _petServices.GetAll();
			return View(pets);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Pet petVM)
		{
			if (!ModelState.IsValid)
			{
				return View(petVM);
			}
			var pet = new Pet
			{
				Name = petVM.Name,

				Description = petVM.Description,
				Image = petVM.Image,
			};
			_petServices.Add(pet);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Edit(int Id)
		{
			var pet = await _petServices.GetById(Id);
			if (pet == null) return View("Error");
			var petVM = new Pet
			{
				Name = pet.Name,
				Description = pet.Description,
				Image = pet.Image,

			};
			return View(petVM);
		}
		[HttpPost]
		public IActionResult Edit(int Id, Pet petVM)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Failed to edit Pet");
				return View("Edit", petVM);
			}
			var pet = new Pet
			{
				Id = Id,
				Name = petVM.Name,
				Description = petVM.Description,
				Image = petVM.Image,
			};
			_petServices.Update(pet);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int Id)
		{
			var pet = await _petServices.GetById(Id);
			if (pet == null) return View("Error");
			return View(pet);
		}
		[HttpPost, ActionName("DeletePet")]
		public async Task<IActionResult> DeletePet(int Id)
		{
			var pet = await _petServices.GetById(Id);
			if (pet == null) return View("Error");
			_petServices.Delete(pet);
			return RedirectToAction("Index");
		}
	}
}
