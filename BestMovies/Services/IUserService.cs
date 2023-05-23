using BestMovies.Models.DbModels;

namespace BestMovies.Services;

public interface IUserService
{

    public Task<User> GetAsync(string guid);

    public Task<string> GetUserName(string guid);
}