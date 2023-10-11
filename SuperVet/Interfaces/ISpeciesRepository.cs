using SuperVet.Models;

namespace SuperVet.Interfaces
{
	public interface ISpeciesRepository : IBaseRepository<Species>
	{
		Task<IEnumerable<Species>> GetSpeciesByPetsId(int PetsId);
	}
}
