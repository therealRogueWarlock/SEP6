using BestMovies.Models.ApiModels;

namespace BestMovies.DataAccess;

public interface IMovieDao
{
    Task<Movie> GetMovieAsync(string idString);
    Task<TrendingMovieWrapper> GetTrendingMoviesAsync();
    Task<CreditWrapper> GetCreditsFromMovieAsync(string idString);
    Task<SearchResultWrapper> GetSimilarMoviesAsync(string idString);
}