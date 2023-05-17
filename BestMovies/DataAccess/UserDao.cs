using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.Models;

namespace BestMovies.DataAccess;

public class UserDao : IUserData
{
    private readonly IDataBaseAccess _dataBaseAccess;

    public UserDao(IDataBaseAccess dataBaseAccess)
    {
        _dataBaseAccess = dataBaseAccess;
    }

    public async Task<User?> GetUser(string username, string password)
    {
        return await _dataBaseAccess.GetUserAsync(username, password);
    }
}