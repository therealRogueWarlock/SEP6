using BestMovies.Models;
using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public interface IUserDao : IDataCrud<User>
{
    Task<User?> GetUserAsync(string username, string password);
    Task<string> GetUsernameFromIdAsync(Guid id);
}