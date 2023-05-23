using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public interface IUserInteractionDao
{
    Task<List<Review>> GetReviewsOfAsync(string subjectId);
    
    Task<List<Comment>> GetCommentsOfAsync(string subjectId);
    
}