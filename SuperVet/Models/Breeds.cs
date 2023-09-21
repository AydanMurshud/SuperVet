using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperVet.Models
{
	public class Breeds
	{
		[Key] 
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Image { get; set; }
		public string? Description { get; set; }
		public int SpeciesId { get; set; }
		public int PetsId { get; set; }
	}
}
