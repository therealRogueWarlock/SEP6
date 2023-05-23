using BestMovies.DataAccess;
using BestMovies.Models.DbModels;

namespace BestMovies.Services.implementation;

public class UserInteractionService : IUserInteractionService
{

    private readonly IUserInteractionDao _userInteractionDao;
    
    public UserInteractionService(IUserInteractionDao userInteractionDao)
    {
        _userInteractionDao = userInteractionDao;
    }

    public List<Review> GetReviewsOf(string subjectId)
    {
        return _userInteractionDao.GetReviewsOf(subjectId);
    }

    public List<Comment> GetCommentsOf(string subjectId)
    {
        return _userInteractionDao.GetCommentsOf(subjectId);
    }

    public async Task AddReviewAsync(Review obj)
    {
        await _userInteractionDao.AddAsync(obj);
    }

    public async Task AddCommentAsync(Comment obj)
    {
        await _userInteractionDao.AddAsync(obj);
    }

    public Task<Comment> DeleteCommentAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> UpdateCommentAsync(Comment obj)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetCommentAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public Task<Review> DeleteReviewAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public Task<Review> UpdateReviewAsync(Review obj)
    {
        throw new NotImplementedException();
    }

    public Task<Review> GetReviewAsync(string guid)
    {
        throw new NotImplementedException();
    }
}