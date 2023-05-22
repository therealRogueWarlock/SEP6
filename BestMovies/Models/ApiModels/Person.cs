using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class Person
{
    [JsonProperty("adult")] public bool? Adult { get; set; }

    [JsonProperty("also_known_as")] public List<string> AlsoKnownAs { get; set; }

    [JsonProperty("biography")] public string Biography { get; set; }

    [JsonProperty("birthday")] public DateTime Birthday { get; set; }

    [JsonProperty("deathday")] public DateTime? Deathday { get; set; }

    [JsonProperty("gender")] public int? Gender { get; set; }

    [JsonProperty("homepage")] public string Homepage { get; set; }

    [JsonProperty("id")] public int? Id { get; set; }

    [JsonProperty("imdb_id")] public string ImdbId { get; set; }

    [JsonProperty("known_for_department")] public string KnownForDepartment { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("place_of_birth")] public string PlaceOfBirth { get; set; }

    [JsonProperty("popularity")] public double? Popularity { get; set; }

    [JsonProperty("profile_path")] public string ProfilePath { get; set; }
}