using Microsoft.AspNetCore.Mvc.Rendering;

namespace AndrewsMovies.Models;

public class MovieGenreViewModel
{
    public List<Movie> Movies { get; set; } = new();

    public SelectList? Genres { get; set; }

    public string? MovieGenre { get; set; }

    public string? SearchString { get; set; }

    public int? MinYear { get; set; }
}