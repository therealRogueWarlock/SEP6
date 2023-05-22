using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.Models;
using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public class UserDao : IUserDao
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

    public Task<User> DeleteAsync(string guid)
    {
        throw new NotImplementedException();
    }
    
    public Task<User> UpdateAsync(User obj)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAsync(string guid)
    {
        throw new NotImplementedException();
    }
    
    public Task<User> GetCollectionAsync(Func<User> searchFunc)
    {
        throw new NotImplementedException();
    }
    
}