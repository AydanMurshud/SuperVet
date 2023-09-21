using SuperVet.Models;

namespace SuperVet.Interfaces
{
	public interface ISpeciesServices
	{
		Task<IEnumerable<Species>> GetAllSpecies();
		Task<Species> GetSpeciesById(int id);
		Task<IEnumerable<Species>> GetSpeciesByPetId(int PetsId);
		bool Add(Species specise);
		bool Update(Species species);
		bool Delete(Species species);
		bool Save();
	}
}
