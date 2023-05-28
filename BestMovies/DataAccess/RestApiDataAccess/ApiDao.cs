using System.Text;
using BestMovies.Models.ApiModels;
using Newtonsoft.Json;

namespace BestMovies.DataAccess.RestApiDataAccess;

public class ApiDao : IApiDao
{
    private readonly IRestApiDataAccess _api;

    public ApiDao(IRestApiDataAccess api)
    {
        _api = api;
    }

    public async Task<SearchResultWrapper> SearchAsync(string searchWord, string searchType, int page, bool adult)
    {
        var url = new StringBuilder();
        url.Append($"search/{searchType}");
        url.Append($"?query={searchWord}");
        url.Append($"&include_adult={adult}");
        url.Append($"&page={page}");

        var response = await _api.SendRequestAsync(url.ToString());
        var result = JsonConvert.DeserializeObject<SearchResultWrapper>(response.Content!);
        return result ?? new SearchResultWrapper();
    }

    public async Task<SearchResultWrapper> SearchGenreAsync(IEnumerable<int> genreIds, int page, bool adult)
    {
        var genres = string.Join(",", genreIds);
        
        var url = new StringBuilder("discover/movie");
        url.Append($"?include_adult={adult}");
        url.Append("&include_video=false");
        url.Append("&language=en-US");
        url.Append($"&page={page}");
        url.Append("&sort_by=popularity.desc");
        url.Append($"&with_genres={genres}");

        var response = await _api.SendRequestAsync(url.ToString());
        var result = JsonConvert.DeserializeObject<SearchResultWrapper>(response.Content ?? "");
        return result ?? new SearchResultWrapper();
    }

    public async Task<GenreWrapper> GetGenreListAsync()
    {
        var url = "genre/movie/list";
        var response = await _api.SendRequestAsync(url);
        var result = JsonConvert.DeserializeObject<GenreWrapper>(response.Content!);
        return result ?? new GenreWrapper();
    }
}