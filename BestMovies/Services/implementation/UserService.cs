using BestMovies.DataAccess;
using BestMovies.Models.DbModels;

namespace BestMovies.Services.implementation;

public class UserService : IUserService
{
    
    
    private readonly IUserDao _userInteractionDao;

    
    
    public Task<User> GetAsync(string guid)
    {
        throw new NotImplementedException();
    }
    
}