using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class GenreWrapper
{
    [JsonProperty("genres")] public List<Genre> Genres { get; set; }
}