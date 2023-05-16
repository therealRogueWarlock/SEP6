using Entities.Models;

namespace BestMovies.Data.CustomServices
{
    public class UserService : IUserService
    {
        
        public Task<User> ValidateUser(User user)
        {
            if (!user.Username.Equals("admin") || !user.Password.Equals("admin")) return null;

            return GetAdminUser();
        }
        
        
        private Task<User> GetAdminUser() {
            return Task.FromResult<User>(new( ) { Username = "admin", Password = "admin", SecurityLevel = 2 });
        }
    }
}