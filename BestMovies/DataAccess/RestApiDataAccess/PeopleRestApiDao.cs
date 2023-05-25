using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.Models.ApiModels;

namespace BestMovies.DataAccess.RestApiDataAccess;

public class PeopleRestApiDao : IPeopleDao
{
    private IDataBaseAccess _dataBaseAccess;

    public PeopleRestApiDao(IDataBaseAccess dataBaseAccess)
    {
        _dataBaseAccess = dataBaseAccess;
    }

    public async Task<Person?> GetPersonAsync(string id)
    {
        return await _dataBaseAccess.GetAsync<Person>(id);
    }
}