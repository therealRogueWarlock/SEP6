using BestMovies.Data;
using BestMovies.Models;
using BestMovies.Services;
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
}