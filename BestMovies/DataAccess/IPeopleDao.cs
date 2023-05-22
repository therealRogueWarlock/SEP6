using BestMovies.Models.ApiModels;

namespace BestMovies.DataAccess;

public interface IPeopleDao
{
    public Person GetPerson(string id);
}