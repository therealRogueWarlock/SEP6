using BestMovies.Models;
using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess.DataBaseAccess;

public interface IDataBaseAccess
{
    Task<User?> GetUserAsync(string username, string password);
    Task<string> GetUsernameFromIdAsync(Guid id);
    Task<List<Review>> GetReviewsOfAsync(string subjectId);
    Task<List<Comment>> GetCommentsOfAsync(string subjectId);
}