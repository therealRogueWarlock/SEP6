using BestMovies.Models.DbModels;

namespace BestMovies.Services;

public interface IUserInteractionService
{
    
    public List<Review> GetReviewsOf(string subjectId);
    
    public List<Comment> GetCommentsOf(string subjectId);
    
    
}