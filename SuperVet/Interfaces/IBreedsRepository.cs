using SuperVet.Models;

namespace SuperVet.Interfaces
{
	public interface IBreedsRepository : IBaseRepository<Breed>
	{
		Task<IEnumerable<Breed>> GetBreedBySpeciesId(int SpeciesId);
	}
}
