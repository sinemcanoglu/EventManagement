namespace EventManagement.Application.DataAccess.Repository
{
    public class GenericRepository<T>(EventManagementContext context) : IGenericRepository<T> where T : class
    {
        protected readonly EventManagementContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
     
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);           
            await _context.SaveChangesAsync();
        }             
    }
}
