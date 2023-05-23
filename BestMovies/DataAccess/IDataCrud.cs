namespace BestMovies.DataAccess;

public interface IDataCrud<T>
{
    
    public Task<T> AddAsync(T obj);
    
    public Task<T> DeleteAsync(string guid);

    public Task<T> UpdateAsync(T obj);

    public Task<T> GetAsync(string guid);
    
}