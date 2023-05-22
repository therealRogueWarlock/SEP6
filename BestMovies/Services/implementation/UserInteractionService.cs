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
        
        _dummyComments.Add(new Comment{});

        return _dummyComments;
    }
}