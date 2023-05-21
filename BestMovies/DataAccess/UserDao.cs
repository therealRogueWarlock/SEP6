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
    public Task<User> AddAsync(User obj)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User obj)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetCollectionAsync(Func<User> searchFunc)
    {
        throw new NotImplementedException();
    }
}