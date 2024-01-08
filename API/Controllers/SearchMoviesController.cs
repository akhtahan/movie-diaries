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
    public class SearchMoviesController : ControllerBase
    {

        private Database _context = new Database();

        // GET: api/searchmovies/search/{genre}
        [HttpGet("search/{genre}")]
        public async Task<IActionResult> SearchByGenre(string genre)
        {
            // Retrieve movies with the specified genre from the database
            var moviesOfSpecifiedGenre = await _context.Movies
                .Where(movie => movie.Genre == genre)
                .ToListAsync();

            return Ok(moviesOfSpecifiedGenre);
        }

        // GET: api/searchmovies/recommendations
        [HttpPost("recommendations")]
        public async Task<IActionResult> GetRecommendations([FromBody] List<Guid> watchedMovieIds)
        {
            var watchedMovies = await _context.WatchedListDB
                .Where(w => watchedMovieIds.Contains(w.WatchedMovieId))
                .ToListAsync();

            var recommendedMovies = new List<RecommendedMovie>();

            //group watched movies by genre
            var watchedMoviesGroupedByGenre = watchedMovies.GroupBy(w => w.Genre);

            foreach (var genreGroup in watchedMoviesGroupedByGenre)
            {
                var genre = genreGroup.Key;
                var genreMovies = await _context.Movies
                    .Where(m => m.Genre == genre)
                    .ToListAsync();

                recommendedMovies.Add(new RecommendedMovie
                {
                    Genre = $"Recommended {genre} Movies...",
                    Movies = genreMovies
                });
            }

            return Ok(recommendedMovies);
        }

        // GET: api/searchmovies/genres
        [HttpGet("genres")]
        public async Task<IActionResult> GetGenres()
        {
            //retrieve distinct genres from the database
            var distinctGenres = await _context.Movies
                .Select(movie => movie.Genre)
                .Distinct()
                .ToListAsync();

            return Ok(distinctGenres);
        }

    }
}