using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class SearchResultWrapper
{
    [JsonProperty("results")] public List<SearchResult> Results { get; set; }

    [JsonProperty("page")] public int Page { get; set; }
}