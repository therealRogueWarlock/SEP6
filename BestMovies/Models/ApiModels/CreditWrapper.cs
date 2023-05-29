using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class CreditWrapper
{
    [JsonProperty("id")] public int? MovieId { get; set; }

    [JsonProperty("cast")] public List<Credit> Credit { get; set; }
}