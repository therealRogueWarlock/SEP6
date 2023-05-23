using BestMovies.DataAccess.DataBaseAccess.util;
using BestMovies.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BestMovies.DataAccess.DataBaseAccess;

public class DataBaseAccess : IDataBaseAccess
{

    public async Task<TEntity> AddAsync<TEntity>(TEntity entity)
    {
        if (entity is null) throw new Exception("Bad entity");
        await using var context = new Context();
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity?> GetAsync<TEntity>(string id) where TEntity : class
    {
        if (!Guid.TryParse(id, out var guid)) throw new Exception("Invalid Id");
        var info = typeof(TEntity).GetProperty("Id");
        await using var context = new Context();
        return await context.Set<TEntity>()
            .Where(x => (Guid) info!.GetValue(x)! == guid)
            .SingleOrDefaultAsync();
    }

    public async Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        if (entity is null) throw new Exception("Bad entity");
        var info = typeof(TEntity).GetProperty("Id");
        await using var context = new Context();
        var dbEntity = await context.Set<TEntity>()
            .Where(x => info!.GetValue(x) == info.GetValue(entity))
            .SingleOrDefaultAsync();

        dbEntity = entity;
        await context.SaveChangesAsync();
        return dbEntity;
    }

    public async Task DeleteAsync<TEntity>(string id) where TEntity : class
    {
        if (!Guid.TryParse(id, out var guid)) throw new Exception("Invalid Id");
        var info = typeof(TEntity).GetProperty("Id");
        await using var context = new Context();
        var entity = await context.Set<TEntity>()
            .Where(x => (Guid) info!.GetValue(x)! == guid)
            .SingleAsync();
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<User?> GetUserAsync(string username, string password)
    {
        await using var context = new Context();
        return await context.Set<User>()
            .Where(u => u.Username == username && u.PasswordHash == password)
            .Include(u => u.Favourites)
            .Include(u => u.Reviews)
            .Include(u => u.FanMovies)
            .ThenInclude(fm => fm.LinkedEntities)
            .SingleOrDefaultAsync();
    }

    public async Task<string> GetUsernameFromIdAsync(Guid id)
    {
        await using var context = new Context();
        var user = await context.Set<User>()
            .Where(u => u.Id == id)
            .SingleAsync();

        return user.Username;
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