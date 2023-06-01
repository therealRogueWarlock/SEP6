using BestMovies.Models.DbModels;

namespace BestMovies.Services
{
    public interface IUserLoginService
    {
        bool IsLoggedIn { get; }
        Task<User>? Validate(string username, string password);

        Task RegisterUser(User newUser);
        Task<User?> GetCurrentUserAsync();
        void ClearCachedUser();
    }
}