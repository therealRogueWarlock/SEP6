using BestMovies.DataAccess.DataBaseAccess.util;
using BestMovies.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BestMovies.DataAccess.DataBaseAccess;

public class ReviewDao : IReviewDao
{
    
    private readonly IDataBaseAccess _dataBaseAccess;

    public ReviewDao(IDataBaseAccess dataBaseAccess)
    {
        _dataBaseAccess = dataBaseAccess;
    }
    
    public async Task<Review> AddAsync(Review obj)
    {
        return await _dataBaseAccess.AddAsync(obj);
    }

    public async Task DeleteAsync(string guid)
    {
        await _dataBaseAccess.DeleteAsync<Review>(guid);
    }

    public async Task<Review> UpdateAsync(Review obj)
    {
        return await _dataBaseAccess.UpdateAsync(obj);
    }

    public async Task<Review?> GetAsync(string guid)
    {
        return await _dataBaseAccess.GetAsync<Review>(guid);
    }

    public async Task<List<Review>> GetReviewsOfAsync(string subjectId)
    {
        await using var context = new Context();
        
        return await context.Set<Review>()
            .Where(r => r.MovieId == subjectId)
            .ToListAsync();
    }
}