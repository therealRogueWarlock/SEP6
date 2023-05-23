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

    public async Task<List<Review>> GetReviewsOfAsync(string subjectId)
    {
        return await _userInteractionDao.GetReviewsOfAsync(subjectId);
    }

    public async Task<List<Comment>> GetCommentsOfAsync(string subjectId)
    {
        return await _userInteractionDao.GetCommentsOfAsync(subjectId);
    }

    public async Task AddReviewAsync(Review obj)
    {
        // await _userInteractionDao.AddAsync(obj);
    }

    public async Task AddCommentAsync(Comment obj)
    {
        // await _userInteractionDao.AddAsync(obj);
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