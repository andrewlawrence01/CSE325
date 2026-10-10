using AndrewsMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace AndrewsMovies.Data;

public class MvcMovieContext : DbContext
{
    public MvcMovieContext(
        DbContextOptions<MvcMovieContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movie => Set<Movie>();
}