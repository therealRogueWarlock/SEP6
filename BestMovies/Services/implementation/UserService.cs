using BestMovies.DataAccess;
using BestMovies.Models.DbModels;

namespace BestMovies.Services.implementation;

public class UserService : IUserService
{
    
    private readonly IUserDao _userDao;
    
    
    public async Task<User> GetAsync(string guid)
    {
        
        return await _userDao.GetAsync(guid);
    }

    public Task<string> GetUserName(string guid)
    {
        throw new NotImplementedException();
    }
}