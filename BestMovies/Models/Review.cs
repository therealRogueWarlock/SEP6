namespace BestMovies.Models;

public class Review
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public float Rating { get; set; }
    public string Comment { get; set; }
    public long MovieId { get; set; }
}