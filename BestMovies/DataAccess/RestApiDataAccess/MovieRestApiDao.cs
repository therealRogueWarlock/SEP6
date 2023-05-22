using System.Text;
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
        
        var url = new StringBuilder($"movie/{id}");
        var response = await _api.SendRequestAsync(url.ToString());
        
        var movie = JsonConvert.DeserializeObject<Movie>(response.Content!);
        return movie ?? new Movie();
    }

    public Task<List<Movie>> GetTrendingMoviesAsync()
    {
        throw new NotImplementedException();
    }
}