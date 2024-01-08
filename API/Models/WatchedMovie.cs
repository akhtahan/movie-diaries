using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class WatchedMovie
    {
        public Guid WatchedMovieId { get; set; }
        public string Title { get; set; }
        public int Runtime { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Synopsis { get; set; }
        public string Picture { get; set; } 

        // private List<Review> _movieReviews = new List<Review>();
        // public IEnumerable<Review> AllMovieReviews
        // {
        //     get
        //     {
        //         return _movieReviews;
        //     }
        // }

        // public void AddReview(Review review)
        // {
        //     if(review.Title == "" || review.Description == ""){
        //         throw new InvalidDataException("Please fill out all required fields.");
        //     } else {
        //         _movieReviews.Add(review);
        //     }

        // }
    
}
}