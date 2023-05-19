using BestMovies.Models;

namespace BestMovies.Data.CustomServices
{
    public interface IUserService
    {

        Task<User>? Validate(string username, string password);

        Task RegisterUser(User newUser);

        User? GetCurrentUser();

    }
}