using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class SearchResult
{
    [JsonProperty("id")] public int Id { get; set; }
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("release_date")] public DateTime? ReleaseDate { get; set; }
    
    [JsonProperty("genre_ids")] public List<int> GenreIds { get; set; }

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

    [JsonProperty("known_for_department")] public string? KnownFor { get; set; }

    [JsonProperty("first_air_date")] public DateTime? FirstAirDate { get; set; }

    public EntityType GetEntityType()
    {
        if (!KnownFor.IsNullOrEmpty())
        {
            return KnownFor switch
            {
                "Acting" => EntityType.Actor,
                "Directing" => EntityType.Director,
                _ => EntityType.Producer
            };
        }

        return FirstAirDate is not null ? EntityType.Tv : EntityType.Movie;
    }
}