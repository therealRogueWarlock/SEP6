namespace BestMovies.DataAccess;

public interface IDataAccess<T>
{
    
    public Task<T> AddAsync(T obj);
    
    public Task<T> DeleteAsync(Guid guid);

    public Task<T> UpdateAsync(T obj);

    public Task<T> GetAsync(Guid guid);

    public Task<T> GetCollectionAsync(Func<T> searchFunc);
    
}