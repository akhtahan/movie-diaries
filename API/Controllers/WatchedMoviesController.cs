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
    public class WatchedMoviesController : ControllerBase
    {
        private Database _context = new Database();


        // GET: api/watchedmovies/watchedlist
        [HttpGet("watchedlist")]
        public async Task<IActionResult> GetAllWatchedMovies()
        {
            var watchedMovies = await _context.WatchedListDB.ToListAsync();

            if (watchedMovies == null || watchedMovies.Count == 0)
            {
                return NotFound("No movies found in the watched list.");
            }

            return Ok(watchedMovies);
        }


        // GET: api/watchedmovies/details/{movieId}
        [HttpGet("details/{movieId}")]
        public async Task<IActionResult> GetMovieDetails(Guid movieId)
        {
            var movies = await _context.Movies.ToListAsync();
            var movie = MoviesCollection.GetMovieDetails(movies, movieId);
            if (movie == null)
            {
                return NotFound();
            }

            // Return detailed information about the movie
            return Ok(movie);
        }

        // POST: api/watchedmovies/add-to-watchedlist/{movieId}
        [HttpPost("add-to-watchedlist/{movieId}")]
        public async Task<IActionResult> AddToWatchedList(Guid movieId)
        {
            var movie = await _context.Movies.FindAsync(movieId);
            var watchedMovies = await _context.WatchedListDB.ToListAsync();

            if (movie == null)
            {
                return NotFound();
            }

            var watchedMovie = WatchedMovieRepository.AddMovie(watchedMovies, movie);

            if (watchedMovie == null)
            {
                return BadRequest("Movie is already in watched page!");
            }

            _context.WatchedListDB.Add(watchedMovie);
            await _context.SaveChangesAsync();

            return Ok("Movie added to watched list successfully");
        }

        //DELETE api/watchedmovies/remove-from-watchedlist/{movieId}
        [HttpDelete("remove-from-watchedlist/{movieId}")]
        public async Task<IActionResult> RemoveFromWatchedListById(Guid movieId)
        {
            var watchedMovies = await _context.WatchedListDB.ToListAsync();

            var removedMovie = WatchedMovieRepository.RemoveMovie(watchedMovies, movieId);

            if (removedMovie == null)
            {
                return NotFound("Movie is not in the watched list so cant be deleted.");
            }

            _context.WatchedListDB.Remove(removedMovie);
            await _context.SaveChangesAsync();

            return Ok("Movie removed from watched list successfully");
        }




    }
}