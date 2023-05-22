using BestMovies.Models.DbModels;

namespace BestMovies.Services
{
    public interface IUserLoginService
    {
        Task<User?> Validate(string username, string password);

        Task<User?> GetCurrentUserAsync();

        void ClearCashedUser();

    }
}