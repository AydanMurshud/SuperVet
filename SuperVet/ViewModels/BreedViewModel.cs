using SuperVet.Models;

namespace SuperVet.ViewModels
{
	public class BreedViewModel : BaseViewModel
	{
		public int PetId { get; set; }
		public List<Pet>? Pets { get; set; }
		public int SpeciesId { get; set; }
		public List<Species>? Species { get; set; }
	}
}