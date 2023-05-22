using BestMovies.Models;
using BestMovies.Models.ApiModels;

namespace BestMovies.Services;

public interface ISearchService
{
    Task<ResultWrapper> SearchAsync(string searchWord, string searchType = "multi", int page = 1, bool adult = false);
}