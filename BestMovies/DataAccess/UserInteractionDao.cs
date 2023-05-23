using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public class UserInteractionDao : IUserInteractionDao
{
    private readonly IDataBaseAccess _dataBaseAccess;

    public UserInteractionDao(IDataBaseAccess dataBaseAccess)
    {
        _dataBaseAccess = dataBaseAccess;
    }

    public async Task<List<Review>> GetReviewsOfAsync(string subjectId)
    {
        return await _dataBaseAccess.GetReviewsOfAsync(subjectId);
    }

    public async Task<List<Comment>> GetCommentsOfAsync(string subjectId)
    {
        return await _dataBaseAccess.GetCommentsOfAsync(subjectId);
    }
}