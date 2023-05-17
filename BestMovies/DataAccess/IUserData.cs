using BestMovies.Models;

namespace BestMovies.DataAccess;

public interface IUserData
{
    Task<User?> GetUser(string username, string password);
}