document.addEventListener('DOMContentLoaded', function () {
    //search page 
    const isSearchPage = window.location.pathname.includes('searchpage.html');

    if (isSearchPage) {
        fetchGenresAndPopulateDropdown();

        const searchButton = document.getElementById("searchButton");
        if (searchButton) {
            searchButton.addEventListener('click', searchByGenre);
        }
    }

    function fetchGenresAndPopulateDropdown() {
        fetch('http://localhost:5007/api/searchmovies/genres', {
            method: "GET",
            headers: {
                "content-type": "application/json"
            }
        })
            .then(response => response.json())
            .then(genres => populateDropdown(genres))
            .catch(error => console.error('Error fetching and populating genres:', error));
    }

    function populateDropdown(genres) {
        const genreDropdown = document.getElementById("genre");

        genreDropdown.innerHTML = "";

        const defaultOption = document.createElement("option");
        defaultOption.text = "Select Genre";
        defaultOption.value = "";
        genreDropdown.add(defaultOption);

        genres.forEach(genre => {
            const option = document.createElement("option");
            option.text = genre;
            option.value = genre;
            genreDropdown.add(option);
        });
    }

    function searchByGenre(event) {
        event.preventDefault();

        const selectedGenre = document.getElementById("genre").value;

        fetch(`http://localhost:5007/api/searchmovies/search/${selectedGenre}`)
            .then(response => response.json())
            .then(data => displaySearchResult(data))
            .catch(error => console.error('Error searching movies by genre:', error));
    }

function displaySearchResult(movies) {
    const searchResultContainer = document.getElementById("searchResult");
    searchResultContainer.innerHTML = "";

    //create a new unordered list
    const movieList = document.createElement("ul");

    movies.forEach(movie => {
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

        const addToWatchlistButton = createButton("Add to Watchlist", () => addToWatchlist(movie.id));
        const viewDetailsButton = createButton("View Details", () => navigateToMovieDetails(movie.id));

        buttonsContainer.appendChild(titleElement);
        buttonsContainer.appendChild(addToWatchlistButton);
        buttonsContainer.appendChild(viewDetailsButton);

        movieDetails.appendChild(movieImage);
        movieDetails.appendChild(buttonsContainer);

        listItem.appendChild(movieDetails);

        //append the list item to the unordered list
        movieList.appendChild(listItem);
    });

    //append the unordered list to the search result container
    searchResultContainer.appendChild(movieList);
}

    function createButton(text, clickHandler) {
        const button = document.createElement("button");
        button.innerText = text;
        button.addEventListener('click', clickHandler);
        return button;
    }

});