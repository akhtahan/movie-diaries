using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace API.Models
{
    public static class MoviesCollection
    {
        public static List<Movie> Movies { get {return movies;} }

        private static List<Movie> movies = new List<Movie>
        {
            new Movie("The Shawshank Redemption", 142, "Drama", 1994, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "../images/shawshank.jpeg"),
            new Movie("The Godfather", 175, "Crime", 1972, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "../images/godfather.jpg"),
            new Movie("The Dark Knight", 152, "Action", 2008, "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", "../images/darkknight.jpg"),
            new Movie("Pulp Fiction", 154, "Crime", 1994, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "../images/pulpfiction.jpg"),
            new Movie("The Lord of the Rings: The Fellowship of the Ring", 178, "Adventure", 2001, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", "../images/lotr_fellowship.jpg"),
            new Movie("Forrest Gump", 142, "Drama", 1994, "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold through the perspective of an Alabama man with an IQ of 75.", "../images/forrestgump.jpg"),
            new Movie("Inception", 148, "Action", 2010, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "../images/inception.jpg"),
            new Movie("Schindler's List", 195, "Biography", 1993, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "../images/schindlerslist.jpg"),
            new Movie("The Matrix", 136, "Action", 1999, "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "../images/matrix.jpeg"),
            new Movie("Fight Club", 139, "Drama", 1999, "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", "../images/fightclub.jpg"),
            new Movie("The Great Gatsby", 143, "Drama", 2013, "A Midwesterner becomes fascinated with his nouveau riche neighbor, who obsesses over his lost love.", "../images/greatgatsby.jpg"),
            new Movie("Avatar", 162, "Action", 2009, "A paraplegic marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.", "../images/avatar.jpg"),
            new Movie("A Beautiful Mind", 135, "Biography", 2001, "After John Nash, a brilliant but asocial mathematician, accepts secret work in cryptography, his life takes a turn for the nightmarish.", "../images/abeautifulmind.jpg"),
            new Movie("Jurassic Park", 127, "Adventure", 1993, "A pragmatic paleontologist visiting an almost complete theme park is tasked with protecting a couple of kids after a power failure causes the park's cloned dinosaurs to run loose.", "../images/jurassicpark.jpg"),
            new Movie("Casablanca", 102, "Drama", 1942, "A cynical American expatriate struggles to decide whether or not he should help his former lover and her fugitive husband escape French Morocco.", "../images/casablanca.jpg"),
            new Movie("Inglourious Basterds", 153, "Adventure", 2009, "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans.", "../images/inglouriousbasterds.jpg"),
            new Movie("The Social Network", 120, "Biography", 2010, "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea.", "../images/socialnetwork.jpg"),
            new Movie("The Revenant", 156, "Action", 2015, "A frontiersman on a fur trading expedition fights for survival after being mauled by a bear and left for dead by members of his own hunting team.", "../images/revenant.jpeg"),
            new Movie("The Wizard of Oz", 102, "Adventure", 1939, "Dorothy Gale is swept away from a farm in Kansas to a magical land of Oz in a tornado and embarks on a quest with her new friends to see the Wizard who can help her return home.", "../images/wizardofoz.jpg"),
            new Movie("Eternal Sunshine of the Spotless Mind", 108, "Drama", 2004, "When their relationship turns sour, a couple undergoes a medical procedure to have each other erased from their memories.", "../images/eternalsunshine.jpg"),
            new Movie("Blade Runner", 117, "Sci-Fi", 1982, "A blade runner must pursue and terminate four replicants who stole a ship in space and have returned to Earth to find their creator.", "../images/bladerunner.jpg"),
        };

         //Get details of a movie in the watchlist
        public static Movie GetMovieDetails(List<Movie> movies, Guid movieId)
        {
            var movie =  movies.Find(m => m.Id == movieId);
            return movie;
        }
    }

        // public static List<Movie> Movies{ return movies;
        // };

}