
// fetch('http://localhost:5007/api/movies',{
//         method : "GET",
//         headers: {
//             "content-type": "application/json"
//         }
//     }
//     )
//     .then(response => response.json())
//     .then(data => {
//         const moviesList = document.getElementById('movies-list');
//         moviesList.innerText = JSON.stringify(data);
//     });

document.addEventListener('DOMContentLoaded', function () {
    // Fetch movies from the API
    fetch("http://localhost:5000/api/movies",{
                method : "GET",
                headers: {
                    "content-type": "application/json"
                }
            }
        )
        .then(response => response.json())
        .then(data => populateMoviesList(data.Movies))
        .catch(error => console.error('Error fetching movies:', error));
});

function populateMoviesList(movies) {
    const moviesList = document.getElementById("moviesList");

    movies.forEach(movie => {
        const listItem = document.createElement("li");
        listItem.innerHTML = '${movie.title} - ${movie.genre}';

        const detailsButton = document.createElement("button");
        detailsButton.innerText = "View Details";
        detailsButton.addEventListener('click', () => navigateToMovieDetails(movie.id));

        listItem.appendChild(detailsButton);
        moviesList.appendChild(listItem);
    });
}

function navigateToMovieDetails(movieId) {
    // window.location.href = 'movie-details.html?id=${movieId}';
}


// fetch("http://localhost:5007/api/movies",{
//     method : "GET",
//     headers: {
//         "content-type": "application/json"
//     }
// })
//     .then(response => response.json())
//     .then(data => populateList(data))

// function populateList(data){
//      data.forEach(item => addItem(item));
// }

// function addItem(item){
//     // var - not recommended to use because its a global variable
//     // use const or let when you want to change to later 
//     const list = document.getElementById("myUL");

//     const span = document.createElement("span");
//     span.classList.add("close")
//     span.innerHTML = "&#x2715"

//     const newItem = document.createElement("li");
//     newItem.innerHTML = item.title;

//     if (item.isComplete===true)
//         newItem.classList.add("checked");
//     newItem.appendChild(span);
//     list.appendChild(newItem);

// }

// document.getElementById("add-button").addEventListener('click', ()=>{
//     // const userInput = document.getElementById("todoItem"); //gives the whole tag
//     const userInputElement = document.getElementById("todoItem");

//     fetch("http://localhost:5007/api/todoitems",{
//         method : "GET",
//         headers: {
//             "content-type": "application/json"
//         },
//         body: JSON.stringify({
//             title: userInputElement.value
//         })
//     })
//         .then(response => response.json())
//         .then(data => {
//             addItem(data)
//             userInputElement.value = ""
//         })

// });

// document.getElementsByClassName("close").addEventListener('click', ()=>{
//     // const userInput = document.getElementById("todoItem"); //gives the whole tag
//     const userInputElement = document.getElementById("todoItem");

//     fetch("http://localhost:5007/api/movies",{
//         method : "DELETE",
//         headers: {
//             "content-type": "application/json"
//         },
//         body: JSON.stringify({
//             title: userInputElement.value
//         })
//     })
//         .then(response => response.json())
//         .then(data => {
//             addItem(data)
//             userInputElement.value = ""
//         })

// });