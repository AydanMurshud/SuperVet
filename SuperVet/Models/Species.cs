namespace SuperVet.Models
{
	public class Species : AnimalBase
	{
		public List<Breed>? Breeds { get; set; }
		public int PetId { get; set; }
	}
}