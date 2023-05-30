using BestMovies.Models.ApiModels;
using BestMovies.Models.DbModels;

namespace BestMovies.Services;

public interface IUserService
{

    public Task<User> GetAsync(string guid);

    public Task<string> GetUserName(string guid);

    public Task AddFavourite(Favourite favourite);

    public Task RemoveFavourite(Favourite favourite);

    public Task UpdateFavourite(Favourite favourite);

    public Task<List<Favourite>> GetFavoritesOf(string guid);
    
    public Task<List<Movie>> GetFavoritesMoviesOf(string guid);
    
    public Task<bool> IsFavorite(string userId, string subjectId);

}