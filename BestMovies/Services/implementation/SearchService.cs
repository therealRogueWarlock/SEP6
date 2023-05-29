using BestMovies.DataAccess;
using BestMovies.Models;
using BestMovies.Models.ApiModels;

namespace BestMovies.Services.implementation;

public class SearchService : ISearchService
{
    private readonly IApiDao _api;

    public SearchService(IApiDao api)
    {
        _api = api;
    }

    public async Task<SearchResultWrapper> SearchAsync(string searchWord, string searchType = "multi", int page = 1, bool adult = false)
    {
        return await _api.SearchAsync(searchWord, searchType, page, adult);
    }

    public async Task<SearchResultWrapper> SearchGenreAsync(IEnumerable<int> genreIds, int page = 1, bool adult = false)
    {
        return await _api.SearchGenreAsync(genreIds, page, adult);
    }

    public async Task<GenreWrapper> GetGenreListAsync()
    {
        return await _api.GetGenreListAsync();
    }
}