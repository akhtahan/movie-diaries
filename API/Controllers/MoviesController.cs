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
    public class MoviesController : ControllerBase
    {
        private Database _context = new Database();

        public IActionResult SeedDatabase()
        {
            var movies = MoviesCollection.Movies;
            foreach (var mov in movies){
                _context.Movies.Add(mov);
            }
            _context.SaveChanges();            
            return Ok();
        }
        //GET: api/movies
        [HttpGet]
        public IActionResult GetMovies()
        {
 
            var movies = _context.Movies.ToList();

            var result = movies;
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllMovies()
        {
            var movies = await _context.Movies.ToListAsync();
           
            if (movies == null || movies.Count == 0)
            {
                return NotFound("No movies found to delete.");
            }

            _context.Movies.RemoveRange(movies);
            await _context.SaveChangesAsync();

            return Ok("All movies deleted successfully.");
        }

        // GET: api/movies/details/{movieId}
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

        // POST: api/movies/add-to-watchlist/{movieId}
        [HttpPost("add-to-watchlist/{movieId}")]
        public async Task<IActionResult> AddToWatchlist(Guid movieId)
        {
            var movie = await _context.Movies.FindAsync(movieId);
            var watchlistMovies = await _context.Watchlist.ToListAsync();

            if (movie == null)
            {
                return NotFound();
            }

            var watchlistMovie = WatchlistRepository.AddMovie(watchlistMovies, movie);

            if (watchlistMovie == null)
            {
                return BadRequest("Movie is already in the watchlist.");
            }

            _context.Watchlist.Add(watchlistMovie);
            await _context.SaveChangesAsync();

            return Ok("Movie added to watchlist successfully");
        }

    }
}