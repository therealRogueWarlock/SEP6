using BestMovies.Models.ApiModels;

namespace BestMovies.DataAccess;

public interface IMovieDao
{
    Task<Movie> GetMovieAsync(string idString);
    Task<List<Movie>> GetTrendingMoviesAsync();
    Task<Credits> GetCreditsFromMovie(string idString);

}