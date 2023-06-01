using BestMovies.Models.ApiModels;
using BestMovies.Models.DbModels;

namespace BestMovies.Services;

public interface IPeopleService
{
    public Task<Person?> GetPersonAsync(string id);
    
    Task<TrendingPersonWrapper> GetTodayTrendingPeopleAsync();
    Task<CelebMovieCredits> GetCelebsMovieCreditsAsync(string id);
}