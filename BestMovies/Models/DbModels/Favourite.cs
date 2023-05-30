namespace BestMovies.Models.DbModels;

public class Favourite
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public EntityType Type { get; set; }
    public string SubjectId { get; set; }
    public int? TopIndex { get; set; }
}