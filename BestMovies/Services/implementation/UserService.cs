using BestMovies.DataAccess;
using BestMovies.Models.ApiModels;
using BestMovies.Models.DbModels;
using Microsoft.IdentityModel.Tokens;

namespace BestMovies.Services.implementation;

public class UserService : IUserService
{
    private readonly IUserDao _userDao;
    private readonly IFavoriteDao _favoriteDao;

    public UserService(IUserDao userDao, IFavoriteDao favoriteDao)
    {
        _userDao = userDao;
        _favoriteDao = favoriteDao;
    }
    
    public async Task<User> GetAsync(string guid)
    {
        return await _userDao.GetAsync(guid);
    }

    public Task<string> GetUserName(string guid)
    {
        if (guid.IsNullOrEmpty())
            throw new ArgumentNullException();
        
        return _userDao.GetUsernameFromIdAsync(guid);
    }

    public async Task AddFavourite(Favourite favourite)
    {
        await _favoriteDao.AddAsync(favourite);
    }

    public async Task RemoveFavourite(Favourite favourite)
    {
        await _favoriteDao.DeleteAsync(favourite.Id.ToString());
    }

    public async Task UpdateFavourite(Favourite favourite)
    {
        await _favoriteDao.UpdateAsync(favourite);
    }

    public async Task<List<Favourite>> GetFavoritesOf(string guid)
    {
        return await _favoriteDao.GetFavoritesOfAsync(guid);
    }

    public Task<List<Movie>> GetFavoritesMoviesOf(string guid)
    {
        throw new NotImplementedException();
    }
    
    public Task<bool> IsFavorite(string userId, string subjectId)
    {
        return _favoriteDao.CheckIfFavorite(userId, subjectId);
    }
}