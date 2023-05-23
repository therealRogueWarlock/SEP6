using System.Text;
using BestMovies.Models;
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

    public async Task<ResultWrapper> SearchAsync(string searchWord, string searchType, int page, bool adult)
    {
        var url = new StringBuilder();
        url.Append($"search/{searchType}");
        url.Append($"?query={searchWord}");
        url.Append($"&include_adult={adult}");
        url.Append($"&page={page}");

        var response = await _api.SendRequestAsync(url.ToString());
        var result = JsonConvert.DeserializeObject<ResultWrapper>(response.Content!);
        return result ?? new ResultWrapper();
    }
}