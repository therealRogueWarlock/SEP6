using BestMovies.Models;
using BestMovies.Models.DbModels;

namespace BestMovies.DataAccess.DataBaseAccess;

public interface IDataBaseAccess
{
    Task<TEntity> AddAsync<TEntity>(TEntity obj);
    Task DeleteAsync<TEntity>(string guid) where TEntity : class;
    Task<TEntity> UpdateAsync<TEntity>(TEntity obj) where TEntity : class;
    Task<TEntity?> GetAsync<TEntity>(string guid, bool useTracking = false) where TEntity : class;
}