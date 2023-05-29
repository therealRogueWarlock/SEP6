using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class TrendingPerson
{
    [JsonProperty("adult")] public bool? Adult { get; set; }

    [JsonProperty("id")] public int? Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("original_name")] public string OriginalName { get; set; }

    [JsonProperty("media_type")] public string MediaType { get; set; }

    [JsonProperty("popularity")] public double? Popularity { get; set; }

    [JsonProperty("gender")] public int? Gender { get; set; }

    [JsonProperty("known_for_department")] public string KnownForDepartment { get; set; }

    [JsonProperty("profile_path")] public string ProfilePath { get; set; }

    [JsonProperty("known_for")] public List<KnownFor> KnownFor { get; set; }
}