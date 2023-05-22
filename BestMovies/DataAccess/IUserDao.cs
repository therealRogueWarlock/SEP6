using BestMovies.Models;
using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public interface IUserDao : IDataCrud<User>
{
    Task<User?> GetUser(string username, string password);
}