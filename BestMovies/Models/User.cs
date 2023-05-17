namespace BestMovies.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public int SecurityLevel { get; set; }
    public bool ShowAdultContent { get; set; }
    public List<Favourite> Favourites { get; set; }
    public List<FanMovie> FanMovies { get; set; }
    public List<Review> Reviews { get; set; }

    
}