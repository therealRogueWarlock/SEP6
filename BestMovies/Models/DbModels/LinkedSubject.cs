namespace BestMovies.Models.DbModels;

public class LinkedSubject
{
    public Guid Id { get; set; }
    public Guid ReferenceId { get; set; }
    public string? Description { get; set; }
    public EntityType Type { get; set; }
    public string SubjectId { get; set; }
}

