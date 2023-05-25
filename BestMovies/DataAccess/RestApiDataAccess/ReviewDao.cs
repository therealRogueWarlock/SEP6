using BestMovies.DataAccess.DataBaseAccess;
using BestMovies.DataAccess.DataBaseAccess.util;
using BestMovies.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BestMovies.DataAccess.RestApiDataAccess;

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

    public Task DeleteAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public Task<Review> UpdateAsync(Review obj)
    {
        throw new NotImplementedException();
    }

    public Task<Review?> GetAsync(string guid)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Review>> GetReviewsOfAsync(string subjectId)
    {
        if (!int.TryParse(subjectId, out var id)) throw new Exception("Invalid Id");

        await using var context = new Context();
        return await context.Set<Review>()
            .Where(r => r.MovieId == id)
            .Include("Comment")
            .ToListAsync();
    }
}