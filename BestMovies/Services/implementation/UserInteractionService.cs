using BestMovies.DataAccess;
using BestMovies.Models.DbModels;

namespace BestMovies.Services.implementation;

public class UserInteractionService : IUserInteractionService
{

    private readonly IUserInteractionDao _userInteractionDao;
    List<Comment> _dummyComments = new List<Comment>();

    public UserInteractionService(IUserInteractionDao userInteractionDao)
    {
        _userInteractionDao = userInteractionDao;
    }

    public List<Review> GetReviewsOf(string subjectId)
    {
        //return _userInteractionDao.GetReviewsOf(subjectId);
        List<Review> _dummyReviews = new List<Review>();

        return _dummyReviews;
    }

    public List<Comment> GetCommentsOf(string subjectId)
    {
        //return _userInteractionDao.GetCommentsOf(subjectId);

        
        _dummyComments.Add(new Comment{Id = Guid.NewGuid(),SubjectId = "john", Text = "Hey this is a comment", UserId = Guid.NewGuid()});
        _dummyComments.Add(new Comment{Id = Guid.NewGuid(),SubjectId = "john", Text = "Hey this is a comment1", UserId = Guid.NewGuid()});
        _dummyComments.Add(new Comment{Id = Guid.NewGuid(),SubjectId = "john", Text = "Hey this is a comment2", UserId = Guid.NewGuid()});
        _dummyComments.Add(new Comment{Id = Guid.NewGuid(),SubjectId = "john", Text = "Hey this is a comment3", UserId = Guid.NewGuid()});
        _dummyComments.Add(new Comment{Id = Guid.NewGuid(),SubjectId = "john", Text = "Hey this is a comment4", UserId = Guid.NewGuid()});

        return _dummyComments;
    }

    public void AddReviewAsync(Review obj)
    {
        throw new NotImplementedException();
    }

    public void AddCommentAsync(Comment obj)
    {
        _dummyComments.Add(obj);
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