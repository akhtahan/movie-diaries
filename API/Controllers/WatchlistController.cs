using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchlistController : ControllerBase
    {
        private Database _context = new Database();

        //GET: api/watchlist
        [HttpGet()]
        public async Task<IActionResult> GetAllWatchlistMovies()
        {
            var watchlistMovies = await _context.Watchlist.ToListAsync();

            if (watchlistMovies == null || watchlistMovies.Count == 0)
            {
                return NotFound("No movies found in the watchlist.");
            }

            return Ok(watchlistMovies);
        }

        // GET: api/watchlist/details/{movieId}
        [HttpGet("details/{movieId}")]
        public async Task<IActionResult> GetMovieDetails(Guid movieId)
        {
            var movies = await _context.Movies.ToListAsync();
            var movie = MoviesCollection.GetMovieDetails(movies, movieId);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // DELETE: api/watchlist/remove-from-watchlist/{movieId}
        [HttpDelete("remove-from-watchlist/{movieId}")]
        public async Task<IActionResult> RemoveFromWatchlistById(Guid movieId)
        {
            var watchlistMovies = await _context.Watchlist.ToListAsync();

            var removedMovie = WatchlistRepository.RemoveMovie(watchlistMovies, movieId);

            if (removedMovie == null)
            {
                return NotFound("Movie is not in the watchlist.");
            }

            _context.Watchlist.Remove(removedMovie);
            await _context.SaveChangesAsync();

            return Ok("Movie removed from watchlist successfully");
        }

        // DELETE: api/watchlist/remove-from-watchlist
        [HttpDelete("remove-from-watchlist")]
        public async Task<IActionResult> RemoveWatchlist()
        {
            var watchlistMovies = await _context.Watchlist.ToListAsync();

            if (!watchlistMovies.Any())
            {
                return NotFound("There are no movies in the watchlist.");
            }

            _context.Watchlist.RemoveRange(watchlistMovies);
            await _context.SaveChangesAsync();

            return Ok("Movie removed from watchlist successfully");
        }
        // POST: api/watchlist/add-to-watched/{movieId}
        [HttpPost("add-to-watched/{movieId}")]
        public async Task<IActionResult> AddToWatched(Guid movieId)
        {
            var movie = await _context.Movies.FindAsync(movieId);
            var watchlistMovies = await _context.Watchlist.ToListAsync();
            var watchedMovies = await _context.WatchedListDB.ToListAsync();

            if (movie == null)
            {
                return NotFound();
            }

            var watchlistMovie = WatchlistRepository.RemoveMovie(watchlistMovies, movieId);

            if (watchlistMovie != null)
            {
                //if movie is in the watchlist then remove it
                _context.Watchlist.Remove(watchlistMovie);
            }

            var watchedMovie = WatchedMovieRepository.AddMovie(watchedMovies, movie);

            if (watchedMovie == null)
            {
                return BadRequest("Movie is already in the watched page!");
            }

            _context.WatchedListDB.Add(watchedMovie);
            await _context.SaveChangesAsync();

            return Ok("Movie added to watched list successfully");
        }

    }
}