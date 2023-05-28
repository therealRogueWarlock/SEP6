using BestMovies.Models;
using BestMovies.Models.ApiModels;

namespace BestMovies.DataAccess;

public interface IApiDao
{
    Task<SearchResultWrapper> SearchAsync(string searchWord, string searchType, int page, bool adult);
    Task<SearchResultWrapper> SearchGenreAsync(IEnumerable<int> genreIds, int page, bool adult);
    Task<GenreWrapper> GetGenreListAsync();
}