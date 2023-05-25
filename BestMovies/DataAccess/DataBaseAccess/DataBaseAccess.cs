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

    public async Task<TEntity?> GetAsync<TEntity>(string id, bool useTracking = false) where TEntity : class
    {
        if (!Guid.TryParse(id, out var guid)) throw new Exception("Invalid Id");
        var info = typeof(TEntity).GetProperty("Id");
        await using var context = new Context();
        if (useTracking)
        {
            return context
                .Set<TEntity>()
                .AsEnumerable()
                .SingleOrDefault(x => (Guid) info!.GetValue(x)! == guid)!;
        }
        return context
            .Set<TEntity>()
            .AsNoTracking()
            .AsEnumerable()
            .SingleOrDefault(x => (Guid) info!.GetValue(x)! == guid)!;
    }

    public async Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        if (entity is null) throw new Exception("Bad entity");
        await using var context = new Context();
        context.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync<TEntity>(string id) where TEntity : class
    {
        if (!Guid.TryParse(id, out var guid)) throw new Exception("Invalid Id");
        var info = typeof(TEntity).GetProperty("Id");
        if (info is null) throw new Exception("Bad entity");
        var entity = Activator.CreateInstance<TEntity>();
        info.SetValue(entity, guid);
        await using var context = new Context();
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

}