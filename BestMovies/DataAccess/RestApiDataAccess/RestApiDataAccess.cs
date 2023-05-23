using RestSharp;
namespace BestMovies.DataAccess.RestApiDataAccess;

public class RestApiDataAccess : IRestApiDataAccess
{
    private const string BaseUrl = "https://api.themoviedb.org/3/";

    public async Task<RestResponse> SendRequestAsync(string url)
    {
        using var client = new RestClient();
        var request = new RestRequest(BaseUrl + url);
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {ConfigVariables.ApiKey}");

        var response = await client.ExecuteAsync(request);

        if (response.IsSuccessful) return response;
        throw new Exception("API request error");
    }
}