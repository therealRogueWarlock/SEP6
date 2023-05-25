using System.Runtime.Serialization;
using BestMovies.DataAccess;
using BestMovies.Models.ApiModels;
using BestMovies.Models.DbModels;

namespace BestMovies.Services.implementation;

public class UserInteractionService : IUserInteractionService
{
    private readonly ICommentDao _commentDao;
    private readonly IReviewDao _reviewDao;
    private readonly IFanMovieDao _fanMovieDao;

    public UserInteractionService(ICommentDao commentDao, IReviewDao reviewDao, IFanMovieDao fanMovieDao)
    {
        _commentDao = commentDao;
        _reviewDao = reviewDao;
        _fanMovieDao = fanMovieDao;
    }

    public async Task<List<Review>> GetReviewsOfAsync(string subjectId)
    {
        return await _reviewDao.GetReviewsOfAsync(subjectId);
    }

    public async Task<List<Comment>> GetCommentsOfAsync(string subjectId)
    {
        return await _commentDao.GetCommentsOfAsync(subjectId);
    }

    public async Task<Review>  AddReviewAsync(Review obj)
    {
        return await _reviewDao.AddAsync(obj);
    }

    public async Task<Comment> AddCommentAsync(Comment obj)
    {
        return await _commentDao.AddAsync(obj);
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

    public Task<bool> SetFavouriteMovieAsync(string movieId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Movie>> GetFavouriteMoviesAsync()
    {
        throw new NotImplementedException();
    }

    public void AddFanMovieAsync(FanMovie fanMovie)
    {
        _fanMovieDao.AddAsync(fanMovie);
    }

    public Task<List<FanMovie>> GetAllFanMoviesByUserAsync(string userGuid)
    {
        var fanMovies = _fanMovieDao.GetFromUserAsync(userGuid);
        return fanMovies;
    }
}