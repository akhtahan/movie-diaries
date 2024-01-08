document.addEventListener('DOMContentLoaded', function () {

    fetchAndDisplayRecommendations();

});

function fetchAndDisplayRecommendations() {
    fetchWatchedMovieIds()
        .then(watchedMovieIds => fetchMovieRecommendations(watchedMovieIds))
        .then(recommendations => displayRecommendations(recommendations))
        .catch(error => console.error('Error fetching and displaying recommendations:', error));
}

function fetchWatchedMovieIds() {
    return fetch('http://localhost:5007/api/watchedmovies/watchedlist', {
        method: "GET",
        headers: {
            "content-type": "application/json"
        }
    })
        .then(response => response.json())
        .then(watchedMovies => watchedMovies.map(movie => movie.watchedMovieId))
        .catch(error => {
            console.error('Error fetching watched movie IDs:', error);
            return [];
        });
}

function fetchMovieRecommendations(watchedMovieIds) {


    return fetch(`http://localhost:5007/api/searchmovies/recommendations`, {
        method: "POST",
        headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify(watchedMovieIds)
    })
        .then(response => response.json())
        .catch(error => {
            console.error('Error fetching movie recommendations:', error);
            return [];
        });
}

function displayRecommendations(recommendations) {
    const recommendationsContainer = document.getElementById("recommendationsContainer");
    recommendationsContainer.innerHTML = "";

    recommendations.forEach(recommendedGenre => {
        const genreHeader = document.createElement("h3");
        genreHeader.innerText = recommendedGenre.genre;
        recommendationsContainer.appendChild(genreHeader);

        const moviesList = document.createElement("ul");
        moviesList.classList.add("movie-list"); 

        if (recommendedGenre.movies.length > 0) {
            recommendedGenre.movies.forEach(movie => {
                const listItem = document.createElement("li");
                listItem.classList.add("movie-item"); 

                const movieImage = document.createElement("img");
                movieImage.src = movie.picture;
                movieImage.alt = `${movie.title} Poster`;
                movieImage.classList.add("movie-image"); 

                const titleElement = document.createElement("h3");
                titleElement.innerText = movie.title;
                titleElement.classList.add("movie-title"); 

                listItem.appendChild(movieImage);
                listItem.appendChild(titleElement);

                moviesList.appendChild(listItem);
            });
        } else {
            const noMoviesItem = document.createElement("li");
            noMoviesItem.innerText = "No movies in this genre.";
            moviesList.appendChild(noMoviesItem);
        }

        recommendationsContainer.appendChild(moviesList);
    });
}





