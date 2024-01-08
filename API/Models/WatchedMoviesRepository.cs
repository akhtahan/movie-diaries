using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Models
{
    public static class WatchedMovieRepository
    {
        //Add a movie to the watched movies list
        public static WatchedMovie AddMovie(List<WatchedMovie> watchedMovies, Movie movie)
        {
            // Check if the movie is already in the watchlist
            if (watchedMovies.Any(w => w.WatchedMovieId == movie.Id))
            {
                //return null since movie is already in watched list
                return null;
            }

            var watchedMovie = new WatchedMovie
            {
                WatchedMovieId = movie.Id,
                Title = movie.Title,
                Runtime = movie.Runtime,
                Genre = movie.Genre,
                ReleaseYear = movie.ReleaseYear,
                Synopsis = movie.Synopsis,
                Picture = movie.Picture
            };

            watchedMovies.Add(watchedMovie);
            return watchedMovie;
        }

        // Remove a movie from the watched movies list 
        public static WatchedMovie RemoveMovie(List<WatchedMovie> watchedMovies, Guid movieId)
        {
            var watchedMovie = watchedMovies.FirstOrDefault(w => w.WatchedMovieId == movieId);

            if (watchedMovie != null)
            {
                watchedMovies.Remove(watchedMovie);
            }

            return watchedMovie;
        }
    }
}