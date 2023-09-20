using System.ComponentModel.DataAnnotations;

namespace SuperVet.Models
{
	public class Pets
	{
		[Key] public int Id { get; set; }

		public string AnimalType { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }	
		public List<Species> Species { get; set; }

	}
}
