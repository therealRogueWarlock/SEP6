namespace BestMovies.DataAccess;

public interface ISearchable<T>
{
    
    public Task<T> GetCollectionAsync(Func<T> searchFunc);

}