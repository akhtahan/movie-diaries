using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Runtime { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string Synopsis { get; set; }
        public string Picture { get; set; }  
        // public List<Review> MovieReviews = new List<Review>();

        // public IEnumerable<Review> AllMovieReviews
        // {
        //     get
        //     {
        //         return MovieReviews;
        //     }
        // }

        public Movie(string title, int runtime, string genre, int releaseYear, string synopsis, string picture)
        {
            Id = Guid.NewGuid(); // Generate a new unique identifier
            Title = title;
            Runtime = runtime;
            Genre = genre;
            ReleaseYear = releaseYear;
            Synopsis = synopsis;
            Picture = picture;
        }

        // public void AddReview(Review review)
        // {
        //     if(review.Title == "" || review.Description == ""){
        //         throw new InvalidDataException("Please fill out all required fields.");
        //     } else {
        //         MovieReviews.Add(review);
        //     }

        // }
    }
}