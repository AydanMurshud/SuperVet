using SuperVet.Models;

namespace SuperVet.ViewModels
{
	public class SpeciesViewModel : BaseViewModel
	{
		public List<Breed>? Breeds { get; set; }
		public int PetId { get; set; }
		public List<Pet>? Pets { get; set; }
	}
}