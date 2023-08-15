using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private Dbclass dbContext;

        public Repository(Dbclass dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<bool> AddAsync(T entity)
        {
            try
            {
                dbContext.Set<T>().AddAsync(entity);
                dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {

                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteAsync(T model)
        {
            try
            {
                dbContext.Set<T>().Remove(model);
                dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {

                return Task.FromResult(false);
            }

        }

        public Task<List<T>> GetAllAsync()
        {
            return dbContext.Set<T>().ToListAsync();
        }

        public T GetUserById(int Id)
        {
            return dbContext.Set<T>().Find(Id);
        }


        public Task<bool> UpdateAsync(T entity)
        {
            try
            {
                dbContext.Set<T>().Attach(entity);
                dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }

        }
    }
}
