using BestMovies.Models;

namespace BestMovies.DataAccess;

public interface IApiDao
{
    Task<ResultWrapper> SearchAsync(string searchWord, string searchType, int page);
}