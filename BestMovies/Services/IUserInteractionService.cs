using BestMovies.Models.DbModels;

namespace BestMovies.Services;

public interface IUserInteractionService
{
    
    public Task<List<Review>> GetReviewsOfAsync(string subjectId);
    
    public Task<List<Comment>> GetCommentsOfAsync(string subjectId);
    
    
    public Task<Review> AddReviewAsync(Review obj);
  
    public Task<Comment> AddCommentAsync(Comment obj);
    
    public Task<Comment> DeleteCommentAsync(string guid);
    
    public Task<Comment> UpdateCommentAsync(Comment obj);


    public Task<Comment> GetCommentAsync(string guid);
    

    public Task<Review> DeleteReviewAsync(string guid);
    

    public Task<Review> UpdateReviewAsync(Review obj);


    public Task<Review> GetReviewAsync(string guid);

}