namespace BestMovies.Models.DbModels;

public class Comment
{
    public Guid Id { get; set; }
    public string AuthorName { get; set; }
    public string Text { get; set; }
    public Guid UserId { get; set; }
    public DateTime Timestamp { get; set; }
    public string SubjectId { get; set; }
}