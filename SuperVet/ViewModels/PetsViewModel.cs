using SuperVet.Models;

namespace SuperVet.ViewModels
{
	public class PetsViewModel : Pet
	{
		public List<Species>? Species { get; set; }
	}
}
