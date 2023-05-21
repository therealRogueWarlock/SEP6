using System.Text;
using BestMovies.Data.CustomServices;
using Microsoft.IdentityModel.Tokens;
using RestSharp;

namespace BestMovies.DataAccess.RestApiDataAccess;

public class RestApiDataAccess : IRestApiDataAccess
{
    private readonly IUserService _userService;

    private const string BaseUrl = "https://api.themoviedb.org/3/";
    private readonly bool _adultContent;

    public RestApiDataAccess(IUserService userService)
    {
        _userService = userService;
        //_adultContent = _userService.GetCurrentUser().ShowAdultContent;
        _adultContent = false;
    }

    public async Task<string> SearchAsync(string searchWord, string searchType, int page)
    {
        var url = new StringBuilder(BaseUrl);
        url.Append($"search/{searchType}");
        url.Append($"?query={searchWord}");
        url.Append($"&include_adult={_adultContent}");
        url.Append($"&page={page}");
        
        using var client = new RestClient();
        var request = new RestRequest(url.ToString());
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {ConfigVariables.ApiKey}");

        var response = await client.ExecuteAsync(request);

        if (response.IsSuccessful) return response.Content!;
        throw new Exception("API ERROR");
    }

    
    
}