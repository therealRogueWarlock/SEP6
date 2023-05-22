namespace BestMovies.Models.DbModels;

public class LinkedSubject
{
    public Guid Id { get; set; }
    public Guid ReferenceId { get; set; }
    public EntityType Type { get; set; }
    public long SubjectId { get; set; }
}

