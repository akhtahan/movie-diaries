document.addEventListener('DOMContentLoaded', function () {
    fetchedWatchedMovies();
});

function fetchedWatchedMovies() {
    fetch('http://localhost:5007/api/watchedmovies/watchedlist', {
        method: "GET",
        headers: {
            "content-type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => populateWatchedList(data))
        .catch(error => console.error('Error fetching watched movies:', error));
}
function populateWatchedList(watchedMovies) {
    const watchedlistContainer = document.getElementById("watchedlistContainer");

    watchedMovies.forEach(movie => {
        const listItem = document.createElement("li");

        const movieDetails = document.createElement("div");
        movieDetails.classList.add("movie-details");

        const movieImage = document.createElement("img");
        movieImage.src = movie.picture;
        movieImage.alt = `${movie.title} Poster`;
        movieImage.classList.add("movie-image");

        const buttonsContainer = document.createElement("div");
        buttonsContainer.classList.add("buttons-container");

        const titleElement = document.createElement("h3");
        titleElement.innerText = movie.title;
        titleElement.classList.add("movie-title");

        const detailsButton = createButton("View Details", () => navigateToMovieDetails(movie.watchedMovieId));
        const deleteButton = createButton("Remove from Watched List", () => removeFromWatched(movie.watchedMovieId));        

        buttonsContainer.appendChild(titleElement);
        buttonsContainer.appendChild(detailsButton);
        buttonsContainer.appendChild(deleteButton);

        movieDetails.appendChild(movieImage);
        movieDetails.appendChild(buttonsContainer);

        listItem.appendChild(movieDetails);

        watchedlistContainer.appendChild(listItem);
    });
}

function createButton(text, clickHandler) {
    const button = document.createElement("button");
    button.innerText = text;
    button.addEventListener('click', clickHandler);
    return button;
}

function removeFromWatched(movieId) {
    fetch(`http://localhost:5007/api/watchedmovies/remove-from-watchedlist/${movieId}`, {
        method: "DELETE",
        headers: {
            "content-type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            //reload watchlist after removal
            fetchedWatchedMovies();
        })
        .catch(error => console.error('Error removing movie from watched list:', error));
}


// Navigate to the watchlist page
function navigateToWatchedlist() {
    window.location.href = './Views/watchedlist.html';
}




