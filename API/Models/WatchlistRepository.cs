namespace API.Models
{
    public static class WatchlistRepository
    {
        // private List<Watchlist> WatchlistMovies { get; set; } = new List<Watchlist>();

        // public List<Watchlist> GetAllWatchlistMovies()
        // {
        //     return WatchlistMovies;
        // }

        // Add a movie to the watchlist
        public static Watchlist AddMovie(List<Watchlist> watchlistMovies,Movie movie)
        {
            // Check if the movie is already in the watchlist
            if (watchlistMovies.Any(w => w.WatchlistId == movie.Id))
            {
                // Movie is already in watchlist, return null or throw an exception
                // depending on your preferred handling
                return null;
            }

            var watchlistMovie = new Watchlist
            {
                WatchlistId = movie.Id,
                Title = movie.Title,
                Runtime = movie.Runtime,
                Genre = movie.Genre,
                ReleaseYear = movie.ReleaseYear,
                Synopsis = movie.Synopsis,
                Picture = movie.Picture
            };

            watchlistMovies.Add(watchlistMovie);
            return watchlistMovie;
        }

        // Remove a movie from the watchlist
        public static Watchlist RemoveMovie(List<Watchlist> watchlistMovies, Guid movieId)
        {
            var watchlistMovie = watchlistMovies.FirstOrDefault(w => w.WatchlistId == movieId);

            if (watchlistMovie != null)
            {
                watchlistMovies.Remove(watchlistMovie);
            }

            return watchlistMovie;
        }
    }
}








// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace API.Models
// {
//     public class WatchlistRepository
//     {
//         private List<Watchlist> WatchlistMovies { get; set; } = new List<Watchlist>();

//         // Add a movie to the watchlist
//         public Watchlist AddMovie(Movie movie)
//         {
//             var watchlistMovie = new Watchlist
//             {
//                 WatchlistId = movie.Id,
//                 Title = movie.Title,
//                 Runtime = movie.Runtime,
//                 Genre = movie.Genre,
//                 Rating = movie.Rating,
//                 Synopsis = movie.Synopsis,
//                 Picture = movie.Picture
//             };

//             WatchlistMovies.Add(watchlistMovie);
//             return watchlistMovie;
//         }

//     //     // Remove a movie from the watchlist
//     //     public void RemoveMovie(Guid movieId)
//     //     {
//     //         var movieToRemove = Movies.Find(m => m.Id == movieId);
//     //         if (movieToRemove != null)
//     //         {
//     //             Movies.Remove(movieToRemove);
//     //         }
//     //     }

//     //     // Move a movie from the watchlist to the watched list
//     //     public void MoveToWatched(Guid movieId, WatchedMovie watchedMovies)
//     //     {
//     //         var movieToMove = Movies.Find(m => m.Id == movieId);
//     //         if (movieToMove != null)
//     //         {
//     //             // Assuming there is a WatchedMovies property in the Watchlist class
//     //             // to store watched movies
//     //             Movies.Remove(movieToMove);
//     //             watchedMovies.Movies.Add(movieToMove);
//     //         }
//     //     }

//     //     // Get details of a movie in the watchlist
//     //     public Movie GetMovieDetails(Guid movieId)
//     //     {
//     //         return Movies.Find(m => m.Id == movieId);
//     //     }
//     }
// }

