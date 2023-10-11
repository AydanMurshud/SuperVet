using System.ComponentModel.DataAnnotations;

namespace SuperVet.Models
{
	public abstract class AnimalBase
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
	}
}