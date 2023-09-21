using SuperVet.Models;

namespace SuperVet.Interfaces
{
	public interface IPetsServices
	{
		Task<IEnumerable<Pets>> GetAllPets();
		Task<Pets> GetPetById(int id);
		bool Add(Pets pet);
		bool Update(Pets pet);
		bool Delete(Pets pets);
		bool Save();
	}
}
