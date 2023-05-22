using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess.DataBaseAccess;

public class FanMovieDao : IFanMovieDao
{
    
    public Task<FanMovie> AddAsync(FanMovie obj)
    {
        throw new NotImplementedException();
    }

    public Task<FanMovie> DeleteAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public Task<FanMovie> UpdateAsync(FanMovie obj)
    {
        throw new NotImplementedException();
    }

    public Task<FanMovie> GetAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public Task<FanMovie> GetCollectionAsync(Func<FanMovie> searchFunc)
    {
        throw new NotImplementedException();
    }

    public FanMovie GetFanMovie(string id)
    {
        throw new NotImplementedException();
    }

    public List<FanMovie> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<FanMovie> GetFromUser(string userId)
    {
        throw new NotImplementedException();
    }
}