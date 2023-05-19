using BestMovies.Models;

namespace BestMovies.Data.CustomServices
{
    public interface ILoginService
    {
        Task<User?> Validate(string username, string password);
    }
}