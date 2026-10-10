
using AndrewsMovies.Data;
using AndrewsMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AndrewsMovies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        // Displays movies and supports title, genre, and year filters.
        public async Task<IActionResult> Index(
            string? searchString,
            string? movieGenre,
            int? minYear)
        {
            IQueryable<Movie> movies = _context.Movie;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                movies = movies.Where(m =>
                    m.Title.Contains(searchString));
            }

            if (!string.IsNullOrWhiteSpace(movieGenre))
            {
                movies = movies.Where(m =>
                    m.Genre == movieGenre);
            }

            if (minYear.HasValue)
            {
                movies = movies.Where(m =>
                    m.ReleaseDate.Year >= minYear.Value);
            }

            var genres = await _context.Movie
                .Select(m => m.Genre)
                .Distinct()
                .OrderBy(g => g)
                .ToListAsync();

            var viewModel = new MovieGenreViewModel
            {
                Movies = await movies
                    .OrderBy(m => m.Title)
                    .ToListAsync(),

                Genres = new SelectList(genres),

                SearchString = searchString,
                MovieGenre = movieGenre,
                MinYear = minYear
            };

            return View(viewModel);
        }

        // Displays a single movie.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // Displays the form for creating a movie.
        public IActionResult Create()
        {
            return View();
        }

        // Saves a new movie.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        // Displays the form for editing a movie.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // Saves edits to an existing movie.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exists = await _context.Movie
                        .AnyAsync(m => m.Id == movie.Id);

                    if (!exists)
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        // Displays the delete confirmation.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // Deletes a movie after confirmation.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie != null)
            {
                _context.Movie.Remove(movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}