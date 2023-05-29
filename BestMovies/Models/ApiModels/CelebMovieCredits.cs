using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class CelebMovieCredits
{
    [JsonProperty("cast")] public List<Cast> Cast { get; set; }

    [JsonProperty("crew")] public List<Crew> Crew { get; set; }

    [JsonProperty("id")] public int? CelebId { get; set; }
}