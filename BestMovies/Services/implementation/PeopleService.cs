using BestMovies.DataAccess;
using BestMovies.Models;
using BestMovies.Models.ApiModels;
using BestMovies.Models.DbModels;

namespace BestMovies.Services.implementation;

public class PeopleService : IPeopleService
{
    private readonly IPeopleDao _peopleDao;

    public PeopleService(IPeopleDao peopleDao)
    {
        _peopleDao = peopleDao;
    }

    public async Task<Person?> GetPersonAsync(string id)
    {
        return await _peopleDao.GetPersonAsync(id);
    }

    public async Task<List<Person>> GetCastOfLinkedSubjectAsync(List<LinkedSubject> peopleInMovie)
    {
        /*TODO: People is NOT saved in our database, but are from the API.
            I have changed the method in PeopleDao.
        */
        List<Person> persons = new List<Person>();

        foreach (var linkedSubject in peopleInMovie)
        {
            if (linkedSubject.Type.Equals(EntityType.Actor))
            {
                var person = await _peopleDao.GetPersonAsync(linkedSubject.SubjectId);
                if (person != null) persons.Add(person);
            }
        }

        return persons;
    }

    public async Task<TrendingPersonWrapper> GetTodayTrendingPeopleAsync()
    {
        return await _peopleDao.GetTodayTrendingPeopleAsync();
    }
}