using BestMovies.Models;

namespace BestMovies.DataAccess;

public interface IUserData : IDataAccess<User>
{
    Task<User?> GetUser(string username, string password);
}