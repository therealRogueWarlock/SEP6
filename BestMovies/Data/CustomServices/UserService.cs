using BestMovies.DataAccess;
using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace BestMovies.Data.CustomServices
{
    public class UserService : IUserService
    {
        
        private readonly IUserData _userData;
        private User? _currentUser;

        public UserService(IUserData userData)
        {
            _userData = userData;
        }
        
        public async Task<User?> Validate(string username, string password)
        {
            _currentUser = await _userData.GetUser(username, password);
            return _currentUser;
        }

        public Task RegisterUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public User? GetCurrentUser()
        {
            return _currentUser;
        }
        
    }
    
}


