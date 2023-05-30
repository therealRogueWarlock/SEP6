using BestMovies.Models;
using BestMovies.Models.ApiModels;

namespace BestMovies.Services;

public interface ISearchService
{
    Task<SearchResultWrapper> SearchAsync(string searchWord, string searchType = "multi", int page = 1, bool adult = false);
    Task<SearchResultWrapper> SearchGenreAsync(IEnumerable<int> genreIds, int page = 1, bool adult = false);
    Task<GenreWrapper> GetGenreListAsync();
}