using BestMovies.DataAccess.DataBaseAccess.util;
using BestMovies.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BestMovies.DataAccess.DataBaseAccess;

public class FanMovieDao : IFanMovieDao
{
    private IDataBaseAccess _dataBaseAccess;

    public FanMovieDao(IDataBaseAccess dataBaseAccess)
    {
        _dataBaseAccess = dataBaseAccess;
    }

    public async Task<FanMovie> AddAsync(FanMovie obj)
    {
        return await _dataBaseAccess.AddAsync(obj);
    }

    public async Task DeleteAsync(string guid)
    {
        await _dataBaseAccess.DeleteAsync<FanMovie>(guid);
    }

    public async Task<FanMovie> UpdateAsync(FanMovie obj)
    {
        return await _dataBaseAccess.UpdateAsync(obj);
    }

    public async Task<FanMovie?> GetAsync(string guid)
    {
        return await _dataBaseAccess.GetAsync<FanMovie>(guid);
    }

    public Task<FanMovie> GetCollectionAsync(Func<FanMovie> searchFunc)
    {
        throw new NotImplementedException();
    }
    
    public async Task<List<FanMovie>> GetAllAsync()
    {
        await using var context = new Context();
        List<FanMovie> fanMovies = await context.Set<FanMovie>()
            .ToListAsync();

        return fanMovies;
    }

    public async Task<List<FanMovie>> GetFromUserAsync(string userId)
    {
        await using var context = new Context();
        List<FanMovie> fanMovies = await context.Set<FanMovie>()
            .Where(fm => fm.UserId.ToString() == userId)
            .ToListAsync();

        return fanMovies;
    }
}