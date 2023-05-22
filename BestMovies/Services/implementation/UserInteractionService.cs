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
        //return _userInteractionDao.GetReviewsOf(subjectId);
        List<Review> _dummyReviews = new List<Review>();

        return _dummyReviews;
    }

    public List<Comment> GetCommentsOf(string subjectId)
    {
        //return _userInteractionDao.GetCommentsOf(subjectId);

        List<Comment> _dummyComments = new List<Comment>();
        
        _dummyComments.Add(new Comment{Id = Guid.NewGuid(),SubjectId = "john", Text = "Hey this is a comment", UserId = Guid.NewGuid()});
        _dummyComments.Add(new Comment{Id = Guid.NewGuid(),SubjectId = "john", Text = "Hey this is a comment1", UserId = Guid.NewGuid()});
        _dummyComments.Add(new Comment{Id = Guid.NewGuid(),SubjectId = "john", Text = "Hey this is a comment2", UserId = Guid.NewGuid()});
        _dummyComments.Add(new Comment{Id = Guid.NewGuid(),SubjectId = "john", Text = "Hey this is a comment3", UserId = Guid.NewGuid()});
        _dummyComments.Add(new Comment{Id = Guid.NewGuid(),SubjectId = "john", Text = "Hey this is a comment4", UserId = Guid.NewGuid()});

        return _dummyComments;
    }
}