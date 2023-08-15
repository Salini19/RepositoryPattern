namespace RepositoryPattern.Repository
{
    public interface IRepository<T> where T : class
    {

        Task<List<T>> GetAllAsync();
        T GetUserById(int Id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
