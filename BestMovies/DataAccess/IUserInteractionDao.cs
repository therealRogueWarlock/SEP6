using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public interface IUserInteractionDao : IDataCrud<Review> , IDataCrud<Comment>
{
    public List<Review> GetReviewsOf(string subjectId);
    
    public List<Comment> GetCommentsOf(string subjectId);
    
}