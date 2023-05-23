using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public interface IReviewDao : IDataCrud<Review>
{
    Task<List<Review>> GetReviewsOfAsync(string subjectId);
    
}