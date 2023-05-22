using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class SearchResult
{
    [JsonProperty("id")] public int Id { get; set; }
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("title")]
    private string Name2
    {
        set => Name = value;
    }

    [JsonProperty("poster_path")] public string Image { get; set; }

    [JsonProperty("profile_path")]
    private string Image2
    {
        set => Image = value;
    }
    
    [JsonProperty("known_for_department")]
    public string? KnownFor { get; set; }
    
    [JsonProperty("first_air_date")]
    public DateTime? FirstAirDate { get; set; }
}

public class ResultWrapper
{
    [JsonProperty("results")]
    public List<SearchResult> Results { get; set; }
    
    [JsonProperty("page")]
    public int Page { get; set; }
}