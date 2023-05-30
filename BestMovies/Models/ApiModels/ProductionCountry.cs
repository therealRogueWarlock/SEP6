using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class ProductionCountry
{
    [JsonProperty("iso_3166_1")] public string Iso31661 { get; set; }

    [JsonProperty("name")] public string Name { get; set; }
}