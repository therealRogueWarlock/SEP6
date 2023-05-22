using BestMovies.DataAccess;
using BestMovies.Models;

namespace BestMovies.Services.implementation;

public class SearchService : ISearchService
{
    private readonly IApiDao _api;

    public SearchService(IApiDao api)
    {
        _api = api;
    }

    public async Task<ResultWrapper> SearchAsync(string searchWord, string searchType = "multi", int page = 1, bool adult = false)
    {
        return await _api.SearchAsync(searchWord, searchType, page, adult);
    }
}