using BestMovies.Models;

namespace BestMovies.Services.CustomServices
{
    public interface IUserLoginService
    {
        Task<User?> Validate(string username, string password);

        Task<User?> GetCurrentUserAsync();

        void ClearCashedUser();

    }
}