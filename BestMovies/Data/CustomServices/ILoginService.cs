using BestMovies.Models;

namespace BestMovies.Data.CustomServices
{
    public interface ILoginService
    {
        Task<User>? ValidateUser(User user);
    }
}