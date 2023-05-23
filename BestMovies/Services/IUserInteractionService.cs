using BestMovies.Models.DbModels;

namespace BestMovies.Services;

public interface IUserInteractionService
{
    
    public List<Review> GetReviewsOf(string subjectId);
    
    public List<Comment> GetCommentsOf(string subjectId);
    
    
    public Task AddReviewAsync(Review obj);
  
    public Task AddCommentAsync(Comment obj);
    
    public Task<Comment> DeleteCommentAsync(string guid);
    
    public Task<Comment> UpdateCommentAsync(Comment obj);


    public Task<Comment> GetCommentAsync(string guid);
    

    public Task<Review> DeleteReviewAsync(string guid);
    

    public Task<Review> UpdateReviewAsync(Review obj);


    public Task<Review> GetReviewAsync(string guid);

}