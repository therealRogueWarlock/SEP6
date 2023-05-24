using BestMovies.DataAccess.DataBaseAccess.util;
using BestMovies.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BestMovies.DataAccess.DataBaseAccess;

public class UserDao : IUserDao
{
    private readonly IDataBaseAccess _dataBaseAccess;

    public UserDao(IDataBaseAccess dataBaseAccess)
    {
        _dataBaseAccess = dataBaseAccess;
    }

    public async Task<User?> GetUserAsync(string username, string password)
    {
        await using var context = new Context();
        return await context.Set<User>()
            .Where(u => u.Username == username && u.PasswordHash == password)
            .Include(u => u.Favourites)
            .Include(u => u.Reviews)
            .Include(u => u.FanMovies)
            .ThenInclude(fm => fm.LinkedEntities)
            .SingleOrDefaultAsync();
    }

    public async Task<string> GetUsernameFromIdAsync(string id)
    {
        // Parse GUID
        if (!Guid.TryParse(id, out Guid userId))
            throw new ArgumentException("value must be a GUID", id);


        // Magic - This does not seem to function correctly
        await using var context = new Context();
        var user = await _dataBaseAccess.GetAsync<User>(id);
        // var user = await context.Set<User>()
        //     .Where(u => u.Id.ToString() == id)
        //     .SingleAsync();

        // Results
        return user.Username;
    }

    public async Task<User> AddAsync(User obj)
    {
        return await _dataBaseAccess.AddAsync(obj);
    }

    public async Task DeleteAsync(string guid)
    {
        await _dataBaseAccess.DeleteAsync<User>(guid);
    }

    public async Task<User> UpdateAsync(User obj)
    {
        return await _dataBaseAccess.UpdateAsync(obj);
    }

    public async Task<User?> GetAsync(string guid)
    {
        return await _dataBaseAccess.GetAsync<User>(guid);
    }
}