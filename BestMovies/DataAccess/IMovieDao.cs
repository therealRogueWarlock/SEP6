using BestMovies.Models.ApiModels;

namespace BestMovies.DataAccess;

public interface IMovieDao
{
    public Task<Movie> GetMovieAsync(string idString);
    
}