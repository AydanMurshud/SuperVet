namespace SuperVet.Interfaces
{
	public interface IBaseRepository<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> GetById(int id);
		bool Add(T pet);
		bool Update(T pet);
		bool Delete(T pets);
		bool Save();
	}
}
