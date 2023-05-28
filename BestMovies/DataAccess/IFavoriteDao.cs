using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public interface IFavoriteDao : IDataCrud<Favourite>
{
    
    public Task<List<Favourite>> GetFavoritesOfAsync(string guid);

    public Task<bool> CheckIfFavorite(string userId, string subjectId);

}