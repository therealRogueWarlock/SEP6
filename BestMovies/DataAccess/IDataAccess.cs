namespace BestMovies.DataAccess;

public interface IDataAccess
{
    
    public Task<T> AddAsync<T>(T obj);
    
    public Task<T> DeleteAsync<T>(Guid guid);

    public Task<T> UpdateAsync<T>(T obj);

    public Task<T> GetAsync<T>(Guid guid);

    public Task<T> GetCollectionAsync<T>(Func<T> searchFunc);
    
}