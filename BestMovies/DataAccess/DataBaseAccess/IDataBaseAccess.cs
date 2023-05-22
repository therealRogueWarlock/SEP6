using BestMovies.Models;

namespace BestMovies.DataAccess.DataBaseAccess;

public interface IDataBaseAccess
{
    Task<User?> GetUserAsync(string username, string password);
}