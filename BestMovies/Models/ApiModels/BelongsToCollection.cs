using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class BelongsToCollection
{
    [JsonProperty("id")] public int? Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("poster_path")] public string PosterPath { get; set; }

    [JsonProperty("backdrop_path")] public string BackdropPath { get; set; }
}