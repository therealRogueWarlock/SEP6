using BestMovies.Models;
using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public interface IUserData : IDataAccess<User>
{
    Task<User?> GetUser(string username, string password);
}