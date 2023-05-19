using BestMovies.Models;

namespace BestMovies.Data.CustomServices
{
    public interface IUserLoginService
    {
        Task<User?> Validate(string username, string password);

        Task<User?> GetCurrentUserAsync();

        void ClearCashedUser();

    }
}