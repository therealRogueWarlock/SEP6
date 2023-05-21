using BestMovies.DataAccess;
using BestMovies.Models;

namespace BestMovies.Services;

public class SearchService : ISearchService
{
    private readonly IApiDao _api;

    public SearchService(IApiDao api)
    {
        _api = api;
    }

    public async Task<ResultWrapper> SearchAsync(string searchWord, string searchType = "multi", int page = 1)
    {
        return await _api.SearchAsync(searchWord, searchType, page);
    }
}