using BestMovies.Models.ApiModels;
using Newtonsoft.Json;

namespace BestMovies.DataAccess.RestApiDataAccess;

public class PeopleRestApiDao : IPeopleDao
{
    private readonly IRestApiDataAccess _api;

    public PeopleRestApiDao(IRestApiDataAccess api)
    {
        _api = api;
    }

    public async Task<Person?> GetPersonAsync(string id)
    {
        if (!int.TryParse(id, out var personId)) throw new Exception("Invalid Id");

        var url = $"person/{personId}";
        var response = await _api.SendRequestAsync(url);

        var person = JsonConvert.DeserializeObject<Person>(response.Content!);
        return person ?? null;
    }

    public async Task<TrendingPersonWrapper> GetTodayTrendingPeopleAsync()
    {
        var url = "trending/person/day";
        var response = await _api.SendRequestAsync(url);

        var people = JsonConvert.DeserializeObject<TrendingPersonWrapper>(response.Content!);
        return people ?? new TrendingPersonWrapper();
    }
}