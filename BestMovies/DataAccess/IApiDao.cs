using BestMovies.Models;
using BestMovies.Models.ApiModels;

namespace BestMovies.DataAccess;

public interface IApiDao
{
    Task<ResultWrapper> SearchAsync(string searchWord, string searchType, int page, bool adult);
}