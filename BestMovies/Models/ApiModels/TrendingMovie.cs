using Newtonsoft.Json;

namespace BestMovies.Models.ApiModels;

public class TrendingMovie
{
    [JsonProperty("adult")] public bool? Adult { get; set; }

    [JsonProperty("backdrop_path")] public string BackdropPath { get; set; }

    [JsonProperty("id")] public int? Id { get; set; }

    [JsonProperty("title")] public string Title { get; set; }

    [JsonProperty("original_language")] public string OriginalLanguage { get; set; }

    [JsonProperty("original_title")] public string OriginalTitle { get; set; }

    [JsonProperty("overview")] public string Overview { get; set; }

    [JsonProperty("poster_path")] public string PosterPath { get; set; }

    [JsonProperty("media_type")] public string MediaType { get; set; }

    [JsonProperty("genre_ids")] public List<int?> GenreIds { get; set; }

    [JsonProperty("popularity")] public double? Popularity { get; set; }

    [JsonProperty("release_date")] public string ReleaseDate { get; set; }

    [JsonProperty("video")] public bool? Video { get; set; }

    [JsonProperty("vote_average")] public double? VoteAverage { get; set; }

    [JsonProperty("vote_count")] public int? VoteCount { get; set; }
}