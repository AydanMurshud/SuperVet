namespace SuperVet.Models
{
	public class Pet : AnimalBase
	{
		public List<Species>? Species { get; set; }
	}
}