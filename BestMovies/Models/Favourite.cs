﻿namespace BestMovies.Models;

public class Favourite
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public EntityType Type { get; set; }
    public long EntityId { get; set; }
}