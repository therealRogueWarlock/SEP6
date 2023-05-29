using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class Genre
{
    [JsonProperty("id")] public int? Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }
}