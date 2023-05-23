using BestMovies.DataAccess;
using BestMovies.Models.ApiModels;

namespace BestMovies.Services.implementation;

public class MovieService : IMovieService
{

    private IMovieDao _movieDao;


    public MovieService(IMovieDao movieDao)
    {
        _movieDao = movieDao;
    }

    public Task<Movie> GetMovieAsync(string idString)
    {
        return _movieDao.GetMovieAsync(idString);
    }
}