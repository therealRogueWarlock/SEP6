using BestMovies.Models.ApiModels;

namespace BestMovies.Services;

public interface IMovieService
{
    public Task<Movie> GetMovieAsync(string idString);
    Task<TrendingMovieWrapper> GetTrendingMoviesAsync();
    Task<Credits> GetCreditsFromMovieAsync(string idString);
    Task<SearchResultWrapper> GetSimilarMoviesAsync(string idString);
}