using BestMovies.Models;

namespace BestMovies.Data.CustomServices
{
    public class UserService : IUserService
    {
        
        
        
        
        public Task<User> ValidateUser(User user)
        {
            if (!user.Username.Equals("admin") || !user.PasswordHash.Equals("admin")) return null;

            return GetAdminUser();
        }

        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }


        private Task<User> GetAdminUser() {
            return Task.FromResult<User>(new( ) { Username = "admin", PasswordHash = "admin", SecurityLevel = 2 });
        }
    }
}