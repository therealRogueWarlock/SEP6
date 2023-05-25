using BestMovies.Models.ApiModels;
using BestMovies.Models.DbModels;

namespace BestMovies.Services;

public interface IPeopleService
{
    public Task<Person?> GetPersonAsync(string id);

    public Task<List<Person>> GetCastOfLinkedSubjectAsync(List<LinkedSubject> peopleInMovie);
    
}