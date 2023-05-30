using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class TrendingMovieWrapper
{
    [JsonProperty("page")] public int? Page { get; set; }

    [JsonProperty("results")] public List<TrendingMovie> TrendingMovies { get; set; }

    [JsonProperty("total_pages")] public int? TotalPages { get; set; }

    [JsonProperty("total_results")] public int? TotalResults { get; set; }
}