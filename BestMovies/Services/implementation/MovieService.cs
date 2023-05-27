using BestMovies.DataAccess;
using BestMovies.Models.ApiModels;

namespace BestMovies.Services.implementation;

public class MovieService : IMovieService
{

    private readonly IMovieDao _movieDao;


    public MovieService(IMovieDao movieDao)
    {
        _movieDao = movieDao;
    }

    public async Task<Movie> GetMovieAsync(string idString)
    {
        return await _movieDao.GetMovieAsync(idString);
    }

    public async Task<TrendingMovieWrapper> GetTrendingMoviesAsync()
    {
        return await _movieDao.GetTrendingMoviesAsync();
    }

    public async Task<Credits> GetCreditsFromMovieAsync(string idString)
    {
        return await _movieDao.GetCreditsFromMovieAsync(idString);
    }
}