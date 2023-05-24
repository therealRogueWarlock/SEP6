namespace BestMovies.Models.DbModels;

public class FanMovie
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid UserId { get; set; }
    public string Description { get; set; }
    public List<LinkedSubject> LinkedEntities { get; set; }
}