using BestMovies.DataAccess;
using BestMovies.Models.DbModels;

namespace BestMovies.Services.implementation;

public class UserService : IUserService
{
    
    private readonly IUserDao _userDao;
    
    
    public Task<User> GetAsync(string guid)
    {
        
        return _userDao.GetAsync(guid);
    }

    public Task<string> GetUserName(string guid)
    {
        throw new NotImplementedException();
    }
}