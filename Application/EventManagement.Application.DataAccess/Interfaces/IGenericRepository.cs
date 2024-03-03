namespace EventManagement.Application.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);     
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
    }
}
