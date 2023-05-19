using BestMovies.DataAccess;
using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace BestMovies.Data.CustomServices
{
    public class UserService : IUserService
    {
        
        private readonly IUserData _userData;

        public UserService(IUserData userData)
        {
            _userData = userData;
        }
        
        public Task<User?> Validate(string username, string password)
        {
            return _userData.GetUser(username,password);
        }

    }
    
}


