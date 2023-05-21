namespace BestMovies.DataAccess.RestApiDataAccess;

public interface IRestApiDataAccess
{
    //Searching
    Task<string> SearchAsync(string searchWord, string searchType, int page);
    
}