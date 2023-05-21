using BestMovies.DataAccess;
using BestMovies.Models;

namespace BestMovies.DummyData;

public class MovieDummyData : IMovieData

{
    private List<Movie> _movies;

    public MovieDummyData()
    {
        
        
    }
    
    
    
    
    
    
    public Task<Movie> AddAsync(Movie obj)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> DeleteAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> UpdateAsync(Movie obj)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> GetAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<List<Movie>> GetCollectionAsync(Func<Movie> searchFunc)
    {
        throw new NotImplementedException();
    }
}