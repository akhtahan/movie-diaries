document.addEventListener('DOMContentLoaded', function () {
    //fetch movies list and populate the list on page load
    fetchWatchlistMovies();
}
)


//fetch and display watchlist movies
function fetchWatchlistMovies() {
    fetch('http://localhost:5007/api/watchlist', {
        method: "GET",
        headers: {
            "content-type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => populateWatchlist(data))
        .catch(error => console.error('Error fetching watchlist movies:', error));

}

function populateWatchlist(watchlistMovies) {
    const watchlistContainer = document.getElementById("watchlistContainer");

    watchlistMovies.forEach(movie => {
        // a container for each movie
        const listItem = document.createElement("li");

        //Movie details
        const movieDetails = document.createElement("div");
        movieDetails.classList.add("movie-details");

        //Movie image 
        const movieImage = document.createElement("img");
        movieImage.src = movie.picture;
        movieImage.alt = `${movie.title} Poster`;
        movieImage.classList.add("movie-image");

        //buttons container
        const buttonsContainer = document.createElement("div");
        buttonsContainer.classList.add("buttons-container");

        //title
        const titleElement = document.createElement("h3");
        titleElement.innerText = movie.title;
        titleElement.classList.add("movie-title");

        //buttons
        const detailsButton = createButton("View Details", () => navigateToMovieDetails(movie.watchlistId));
        const removeFromWatchlistButton = createButton("Remove from Watchlist", () => removeFromWatchlist(movie.watchlistId));
        const moveToWatchedButton = createButton("Move to Watched", () => addToWatched(movie.watchlistId));

        //append elements to the buttons container
        buttonsContainer.appendChild(titleElement);
        buttonsContainer.appendChild(detailsButton);
        buttonsContainer.appendChild(removeFromWatchlistButton);
        buttonsContainer.appendChild(moveToWatchedButton);

        //append movie image and buttons container to the movie details
        movieDetails.appendChild(movieImage);
        movieDetails.appendChild(buttonsContainer);

        //append the movie details to the list item
        listItem.appendChild(movieDetails);

        //append the list item to the watchlist container
        watchlistContainer.appendChild(listItem);
    });
}

function createButton(text, clickHandler) {
    const button = document.createElement("button");
    button.innerText = text;
    button.addEventListener('click', clickHandler);
    return button;
}

//add movie to the watchlist
function addToWatchlist(movieId) {
    fetch(`http://localhost:5007/api/movies/add-to-watchlist/${movieId}`, {
        method: "POST",
        headers: {
            "content-type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => {
            //log response from server
            console.log(data); 
            navigateToWatchlist();
        })
        .catch(error => console.error('Error adding movie to watchlist:', error));
}

//remove movie from the watchlist
function removeFromWatchlist(movieId) {
    fetch(`http://localhost:5007/api/watchlist/remove-from-watchlist/${movieId}`, {
        method: "DELETE",
        headers: {
            "content-type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log(data); 
            //reload the watchlist after removal
            fetchWatchlistMovies();
        })
        .catch(error => console.error('Error removing movie from watchlist:', error));
}

// Move movie from watchlist to watched
function addToWatched(movieId) {
    fetch(`http://localhost:5007/api/watchlist/add-to-watched/${movieId}`, {
        method: "POST",
        headers: {
            "content-type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log(data); 
            // removeFromWatchlist(movieId);
            navigateToWatchedlist();
        })
        .catch(error => console.error('Error adding movie to watchlist:', error));
}

// // Navigate to the watchlist page
// function navigateToWatchlist() {
//     window.location.href = 'watchlist.html';
// }
