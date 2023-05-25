using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public interface IFanMovieDao : IDataCrud<FanMovie>
{
    Task<List<FanMovie>> GetAllAsync();
    Task<List<FanMovie>> GetFromUserAsync(string userId);
}