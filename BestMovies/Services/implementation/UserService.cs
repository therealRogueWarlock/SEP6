using BestMovies.DataAccess;
using BestMovies.Models.DbModels;
using Microsoft.IdentityModel.Tokens;

namespace BestMovies.Services.implementation;

public class UserService : IUserService
{
    private readonly IUserDao _userDao;

    public UserService(IUserDao userDao)
    {
        _userDao = userDao;
    }

    public Task<User> GetAsync(string guid)
    {
        return _userDao.GetAsync(guid);
    }

    public Task<string> GetUserName(string guid)
    {
        if (guid.IsNullOrEmpty())
            throw new ArgumentNullException();
        
        return _userDao.GetUsernameFromIdAsync(guid);
    }
}