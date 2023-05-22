using BestMovies.Models.ApiModels;

namespace BestMovies.DataAccess;

public interface IMovieDao
{
    public Movie GetMovie(string id);
    
}