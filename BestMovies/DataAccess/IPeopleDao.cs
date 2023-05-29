using BestMovies.Models.ApiModels;

namespace BestMovies.DataAccess;

public interface IPeopleDao
{
    public Task<Person?> GetPersonAsync(string id);
    Task<TrendingPersonWrapper> GetTodayTrendingPeopleAsync();
    Task<CelebMovieCredits> GetCelebsMovieCreditsAsync(string id);
}