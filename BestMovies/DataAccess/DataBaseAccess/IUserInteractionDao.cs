using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess.DataBaseAccess;

public class UserInteractionDao : IUserInteractionDao
{
    public Task<Review> AddAsync(Review obj)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> AddAsync(Comment obj)
    {
        throw new NotImplementedException();
    }

    Task<Comment> IDataCrud<Comment>.DeleteAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> UpdateAsync(Comment obj)
    {
        throw new NotImplementedException();
    }

    Task<Comment> IDataCrud<Comment>.GetAsync(string guid)
    {
        throw new NotImplementedException();
    }

    Task<Review> IDataCrud<Review>.DeleteAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public Task<Review> UpdateAsync(Review obj)
    {
        throw new NotImplementedException();
    }

    Task<Review> IDataCrud<Review>.GetAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public List<Review> GetReviewsOf(string subjectId)
    {
        throw new NotImplementedException();
    }

    public List<Comment> GetCommentsOf(string subjectId)
    {
        throw new NotImplementedException();
    }
}