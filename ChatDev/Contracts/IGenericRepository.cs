namespace ChatDev.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(Guid? id);
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task<bool> Exists(Guid id);
        Task<List<T>> GetAllAsync();
    }
}
