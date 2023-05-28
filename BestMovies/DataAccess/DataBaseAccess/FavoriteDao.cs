using BestMovies.DataAccess.DataBaseAccess.util;
using BestMovies.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BestMovies.DataAccess.DataBaseAccess;

public class FavoriteDao : IFavoriteDao
{
    
    private readonly IDataBaseAccess _dataBaseAccess;

    public FavoriteDao(IDataBaseAccess dataBaseAccess)
    {
        _dataBaseAccess = dataBaseAccess;
    }

    public async Task<Favourite> AddAsync(Favourite obj)
    {
        return await _dataBaseAccess.AddAsync(obj);
    }

    public async Task DeleteAsync(string guid)
    {
        await _dataBaseAccess.DeleteAsync<Favourite>(guid);
    }

    public async Task<Favourite> UpdateAsync(Favourite obj)
    {
        return await _dataBaseAccess.UpdateAsync(obj);
    }

    public async Task<Favourite?> GetAsync(string guid)
    {
        return await _dataBaseAccess.GetAsync<Favourite>(guid);
    }
    
    
    
    public async Task<List<Favourite>> GetFavoritesOfAsync(string id)
    {
        if (!Guid.TryParse(id, out var guid)) throw new Exception("Invalid Id");
        await using var context = new Context();
        
        return await context.Set<Favourite>()
            .Where(f => f.UserId == guid)
            .ToListAsync();
    }

    public async Task<bool> CheckIfFavorite(string userId, string subjectId)
    {
        
        if (!Guid.TryParse(userId, out var guid)) throw new Exception("Invalid Id");
        
        await using var context = new Context();
        
        var fav = await context.Set<Favourite>()
            .Where(f => f.UserId == guid)
            .Where(f => f.SubjectId == subjectId)
            .FirstOrDefaultAsync();
        
        return fav != null;
    }
}