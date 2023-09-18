using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperVet.Models
{
	public class Species
	{
		[Key] public int Id { get; set; }
		public string Name { get; set; }

		public string Description { get; set; }

		public string Image {get; set; }

		[ForeignKey("BreedsId")]
		public int BreedsId { get; set; }
		public List<Breeds> Breeds { get; set; }
	}
}
