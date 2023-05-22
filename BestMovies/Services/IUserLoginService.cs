using BestMovies.Models;
using BestMovies.Models.DbModels;

namespace BestMovies.Data.CustomServices
{
    public interface IUserLoginService
    {
        Task<User?> Validate(string username, string password);

        Task<User?> GetCurrentUserAsync();

        void ClearCashedUser();

    }
}