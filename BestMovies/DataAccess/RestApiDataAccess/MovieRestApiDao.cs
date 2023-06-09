using BestMovies.Models.ApiModels;
using Newtonsoft.Json;

namespace BestMovies.DataAccess.RestApiDataAccess;

public class MovieRestApiDao : IMovieDao
{
    private readonly IRestApiDataAccess _api;

    public MovieRestApiDao(IRestApiDataAccess api)
    {
        _api = api;
    }

    public async Task<Movie> GetMovieAsync(string idString)
    {
        if (!int.TryParse(idString, out var id)) throw new Exception("Invalid Id");
        
        var url = $"movie/{id}";
        var response = await _api.SendRequestAsync(url);
        
        var movie = JsonConvert.DeserializeObject<Movie>(response.Content!);
        return movie ?? new Movie();
    }
    
    public async Task<SearchResultWrapper> GetSimilarMoviesAsync(string idString)
    {
        if (!int.TryParse(idString, out var id)) throw new Exception("Invalid Id");
        
        var url = $"movie/{id}/similar";
        var response = await _api.SendRequestAsync(url);
        
        var movie = JsonConvert.DeserializeObject<SearchResultWrapper>(response.Content!);
        return movie ?? new SearchResultWrapper();
    }

    public async Task<TrendingMovieWrapper> GetTrendingMoviesAsync()
    {
        var url = "trending/movie/week";
        var response = await _api.SendRequestAsync(url);

        var movies = JsonConvert.DeserializeObject<TrendingMovieWrapper>(response.Content!);
        return movies ?? new TrendingMovieWrapper();
    }

    public async Task<CreditWrapper> GetCreditsFromMovieAsync(string idString)
    {
        if (!int.TryParse(idString, out var id)) throw new Exception($"Invalid Id: {idString}");

        var url = $"movie/{id}/credits";
        var response = await _api.SendRequestAsync(url);

        var credits = JsonConvert.DeserializeObject<CreditWrapper>(response.Content!);
        return credits ?? new CreditWrapper();
    }
}