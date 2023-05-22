using BestMovies.DataAccess.RestApiDataAccess;
using BestMovies.Models;
using Newtonsoft.Json;

namespace BestMovies.DataAccess;

public class ApiDao : IApiDao
{
    private readonly IRestApiDataAccess _api;

    public ApiDao(IRestApiDataAccess api)
    {
        _api = api;
    }

    public async Task<ResultWrapper> SearchAsync(string searchWord, string searchType, int page)
    {
        var resultString = await _api.SearchAsync(searchWord, searchType, page);
        var result = JsonConvert.DeserializeObject<ResultWrapper>(resultString);
        return result ?? new ResultWrapper();
    }
}