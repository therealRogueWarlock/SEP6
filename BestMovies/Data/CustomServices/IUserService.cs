using BestMovies.Models;

namespace BestMovies.Data.CustomServices
{
    public interface IUserService
    {
        Task<User>? ValidateUser(User user);
        User GetCurrentUser();
    }
}