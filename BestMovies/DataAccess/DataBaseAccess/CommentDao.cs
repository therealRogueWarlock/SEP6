using BestMovies.DataAccess.DataBaseAccess.util;
using BestMovies.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BestMovies.DataAccess.DataBaseAccess;

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

    public async Task DeleteAsync(string guid)
    {
        await _dataBaseAccess.DeleteAsync<Review>(guid);
    }

    public async Task<Comment> UpdateAsync(Comment obj)
    {
        return await _dataBaseAccess.UpdateAsync(obj);
    }

    public async Task<Comment?> GetAsync(string guid)
    {
        return await _dataBaseAccess.GetAsync<Comment>(guid);
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