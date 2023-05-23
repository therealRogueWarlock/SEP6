using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess;

public interface ICommentDao : IDataCrud<Comment>
{
    Task<List<Comment>> GetCommentsOfAsync(string subjectId);
}