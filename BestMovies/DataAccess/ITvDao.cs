using BestMovies.Models.ApiModels;

namespace BestMovies.DataAccess;

public interface ITvDao
{
    public TvShow GetTvShow(string id);
}