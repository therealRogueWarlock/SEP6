using System.ComponentModel.DataAnnotations;

namespace BestMovies.Models.DbModels;

public class Review
{
    public Guid Id { get; set; }
    public string AuthorName { get; set; }
    public Guid UserId { get; set; }
    
    [Range(0, 5)]
    public int Rating { get; set; }
    public Comment? Comment { get; set; }
    public long MovieId { get; set; }
}