using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public interface IFanMovieDao : IDataCrud<FanMovie>
{
    public FanMovie GetFanMovie(string id);
    
    public List<FanMovie> GetAll();

    public List<FanMovie> GetFromUser(string userId);

    
}