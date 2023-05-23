using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.DataAccess.DataBaseAccess.util;
using BestMovies.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BestMovies.DataAccess.RestApiDataAccess;

public class CommentDao : ICommentDao
{
    
    
    private readonly IDataBaseAccess _dataBaseAccess;

    public CommentDao(IDataBaseAccess dataBaseAccess)
    {
        _dataBaseAccess = dataBaseAccess;
    }
    
    public async Task<Comment> AddAsync(Comment obj)
    {
        return await _dataBaseAccess.AddAsync(obj);
    }

    public Task DeleteAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> UpdateAsync(Comment obj)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> GetAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Comment>> GetCommentsOfAsync(string subjectId)
    {
        await using var context = new Context();
        return await context.Set<Comment>()
            .Where(c => c.SubjectId == subjectId)
            .OrderBy(c => c.Timestamp)
            .ToListAsync();
    }
}