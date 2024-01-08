document.addEventListener('DOMContentLoaded', function () {
    //fetch movies list and populate the list on page load
    fetchMoviesList();

    //check if the current page is the movie details page
    const isMovieDetailsPage = window.location.pathname.includes('movie-details.html');

    if (isMovieDetailsPage) {
        //extract movie ID from the URL query parameters
        const urlParams = new URLSearchParams(window.location.search);
        const movieId = urlParams.get('id');

        if (movieId) {
            fetchMovieDetails(movieId);
        } else {
            console.error('Movie ID not provided in the URL.');
        }
    }
}
)

//fetch movies list and populate the list on the page
function fetchMoviesList() {
    fetch('http://localhost:5007/api/movies', {
        method: "GET",
        headers: {
            "content-type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => populateMoviesList(data))
        .catch(error => console.error('Error fetching movies:', error));
}

function populateMoviesList(movies) {
    const moviesList = document.getElementById("moviesList");

    movies.forEach(movie => {
        const listItem = document.createElement("li");

        // a div to contain the image and other details
        const movieDetailsContainer = document.createElement("div");
        movieDetailsContainer.classList.add("movie-details"); 

        // an image element
        const movieImage = document.createElement("img");
        movieImage.src = movie.picture;
        movieImage.alt = `${movie.title} Poster`;
        movieImage.classList.add("movie-image");

        // Buttons container
        const buttonsContainer = document.createElement("div");
        buttonsContainer.classList.add("buttons-container");

        // Title
        const titleElement = document.createElement("h3");
        titleElement.innerText = movie.title;
        titleElement.classList.add("movie-title");

        // buttons
        const detailsButton = createButton("View Details", () => navigateToMovieDetails(movie.id));
        const addToWatchlistButton = createButton("Add to Watchlist", () => addToWatchlist(movie.id));
        const alreadyWatchedButton = createButton("Already Watched", () => markAsWatched(movie.id));

        //append elements to buttons container
        buttonsContainer.appendChild(titleElement);
        buttonsContainer.appendChild(detailsButton);
        buttonsContainer.appendChild(addToWatchlistButton);
        buttonsContainer.appendChild(alreadyWatchedButton);

        //append movie image and buttons container to the movie details
        movieDetailsContainer.appendChild(movieImage);
        movieDetailsContainer.appendChild(buttonsContainer);

        //append movie details to list item
        listItem.appendChild(movieDetailsContainer);

        //append list item to movies list container
        moviesList.appendChild(listItem);
    });
}




// Add this function to mark a movie as watched
function markAsWatched(movieId) {
    fetch(`http://localhost:5007/api/watchedmovies/add-to-watchedlist/${movieId}`, {
        method: "POST",
        headers: {
            "content-type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => {
            //logging response from server
            console.log(data);
            // reloading watched list after removal to reflect updated list
            fetchedWatchedMovies();
        })
        .catch(error => console.error('Error removing movie from watched list:', error));

}

//fetching and displaying movie details
function fetchMovieDetails(movieId) {
    fetch(`http://localhost:5007/api/movies/details/${movieId}`, {
        method: "GET",
        headers: {
            "content-type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => displayMovieDetails(data))
        .catch(error => alert(error));
}


//populating the movie details on the page
function displayMovieDetails(movie) {

    const movieImage = document.getElementById("movieImage");
    movieImage.src = movie.picture;
    movieImage.alt = `${movie.title} Poster`;

    const movieTitle = document.getElementById("movieTitle");
    movieTitle.innerText = movie.title;

    const movieRuntime = document.getElementById("movieRuntime");
    movieRuntime.innerText = `Runtime: ${movie.runtime} minutes`;

    const movieReleaseYear = document.getElementById("movieReleaseYear");
    movieReleaseYear.innerText = `Release Year: ${movie.releaseYear}`;

    const movieGenre = document.getElementById("movieGenre");
    movieGenre.innerText = `Genre: ${movie.genre}`;

    const movieSynopsis = document.getElementById("movieSynopsis");
    movieSynopsis.innerText = `Synopsis: ${movie.synopsis}`;
}

//navigating to the movie details page
function navigateToMovieDetails(movieId) {
    window.location.href = `movie-details.html?id=${movieId}`;
}
