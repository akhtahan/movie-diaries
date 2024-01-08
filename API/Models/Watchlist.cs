using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace API.Models
{
    public class Watchlist
    {
        public Guid WatchlistId { get; set; }
        public string Title { get; set; }
        public int Runtime { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Synopsis { get; set; }
        public string Picture { get; set; }  
        // public List<Movie> Movies { get; set; } = new List<Movie>();

        // Add a movie to the watchlist
        // public void AddMovie(Movie movie)
        // {
        //     Movies.Add(movie);
        // }

        // // Remove a movie from the watchlist
        // public void RemoveMovie(Guid movieId)
        // {
        //     var movieToRemove = Movies.Find(m => m.Id == movieId);
        //     if (movieToRemove != null)
        //     {
        //         Movies.Remove(movieToRemove);
        //     }
        // }

        // // Move a movie from the watchlist to the watched list
        // public void MoveToWatched(Guid movieId, WatchedMovie watchedMovies)
        // {
        //     var movieToMove = Movies.Find(m => m.Id == movieId);
        //     if (movieToMove != null)
        //     {
        //         // Assuming there is a WatchedMovies property in the Watchlist class
        //         // to store watched movies
        //         Movies.Remove(movieToMove);
        //         watchedMovies.Movies.Add(movieToMove);
        //     }
        // }

        // // Get details of a movie in the watchlist
        // public Movie GetMovieDetails(Guid movieId)
        // {
        //     return Movies.Find(m => m.Id == movieId);
        // }

    }
}
