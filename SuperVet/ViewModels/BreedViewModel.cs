using SuperVet.Models;

namespace SuperVet.ViewModels
{
	public class BreedViewModel
	{
		public int Id { get; set; }
		public string? Name { get; set; }

		public string? Description { get; set; }

		public string? Image { get; set; }
		public int PetsId { get; set; }
		public List<Pets>? Pets { get; set; }
		public int SpeciesId { get; set; }
		public List<Species>? Species { get; set; }
	}
}
