using SuperVet.Models;

namespace SuperVet.ViewModels
{
	public class EditPetsViewModel
	{
		public int Id { get; set; }

		public string AnimalType { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }

		public List<Species>? Species { get; set; }
	}
}
