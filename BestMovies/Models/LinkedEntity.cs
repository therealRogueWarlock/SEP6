namespace BestMovies.Models;

public class LinkedEntity
{
    public Guid Id { get; set; }
    public Guid ReferenceId { get; set; }
    public EntityType Type { get; set; }
    public long EntityId { get; set; }
}

