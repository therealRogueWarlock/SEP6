using BestMovies.DataAccess.DataBaseAccess.util;
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

}