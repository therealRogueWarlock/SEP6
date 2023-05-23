using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess.DataBaseAccess;

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

    public async Task<string> GetUsernameFromIdAsync(Guid id)
    {
        return await _dataBaseAccess.GetUsernameFromIdAsync(id);
    }

    public async Task<User> AddAsync(User obj)
    {
        return await _dataBaseAccess.AddAsync(obj);
    }

    public async Task DeleteAsync(string guid)
    {
        await _dataBaseAccess.DeleteAsync<User>(guid);
    }
    
    public async Task<User> UpdateAsync(User obj)
    {
        return await _dataBaseAccess.UpdateAsync(obj);
    }

    public async Task<User?> GetAsync(string guid)
    {
        return await _dataBaseAccess.GetAsync<User>(guid);
    }
    
}