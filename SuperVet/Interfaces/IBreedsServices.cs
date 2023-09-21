using SuperVet.Models;

namespace SuperVet.Interfaces
{
	public interface IBreedsServices
	{
		Task<IEnumerable<Breeds>> GetAllBreeds();
		Task<Breeds> GetBreedById(int Id);
		Task<IEnumerable<Breeds>> GetBreedBySpeciesId(int SpeciesId);

		bool Add(Breeds breeds);
		bool Update(Breeds breeds);
		bool Delete(Breeds breeds);
		bool Save();
	}
}
