using RestSharp;

namespace BestMovies.DataAccess.RestApiDataAccess;

public interface IRestApiDataAccess
{
    Task<RestResponse> SendRequestAsync(string url);

}