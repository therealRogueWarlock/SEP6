using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.DataAccess.DataBaseAccess.util;
using BestMovies.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BestMovies.DataAccess;

public class UserInteractionDao : IUserInteractionDao
{
    private readonly IDataBaseAccess _dataBaseAccess;

    public UserInteractionDao(IDataBaseAccess dataBaseAccess)
    {
        _dataBaseAccess = dataBaseAccess;
    }

    public async Task<List<Review>> GetReviewsOfAsync(string subjectId)
    {
        if (!int.TryParse(subjectId, out var id)) throw new Exception("Invalid Id");

        await using var context = new Context();
        return await context.Set<Review>()
            .Where(r => r.MovieId == id)
            .ToListAsync();
    }

    public async Task<List<Comment>> GetCommentsOfAsync(string subjectId)
    {
        await using var context = new Context();
        return await context.Set<Comment>()
            .Where(c => c.SubjectId == subjectId)
            .ToListAsync();
    }
}