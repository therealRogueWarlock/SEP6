using BestMovies.Data;
using BestMovies.DataAccess.DataBaseAccess.util;
using BestMovies.Models;
using BestMovies.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BestMovies.DataAccess.DataBaseAccess;

public class DataBaseAccess : IDataBaseAccess
{
    
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

    public async Task<string> GetUsernameFromIdAsync(Guid id)
    {
        await using var context = new Context();
        var user = await context.Set<User>()
            .Where(u => u.Id == id)
            .SingleAsync();

        return user.Username;
    }
}