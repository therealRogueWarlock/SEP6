using BestMovies.Models;
using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess.DataBaseAccess;

public interface IDataBaseAccess
{
    Task<User?> GetUserAsync(string username, string password);
}