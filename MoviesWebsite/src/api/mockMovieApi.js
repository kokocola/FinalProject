import delay from './delay';

// This file mocks a web API by working with the hard-coded data below.
// It uses setTimeout to simulate the delay of an AJAX call.
// All calls return promises.
const movies = [
  {
    titleId: "1",
    titleType: "Movie 1",
    primaryTitle: "Movie 1 Test",
    originalTitle : "Original Movie 1",
    isAdult: false,
    startYear: 2000,
    endYear: 2001,
    runTimeMinutes: 122,
    genre: "Action"
  },
  {
    titleId: "2",
    titleType: "Movie 2",
    primaryTitle: "Movie 2 Test",
    originalTitle : "Original Movie 2",
    isAdult: false,
    startYear: 1998,
    endYear: 2005,
    runTimeMinutes: 100,
    genre: "Drama"
  },
  {
    titleId: "3",
    titleType: "Movie 3",
    primaryTitle: "Movie 3 Test",
    originalTitle : "Original Movie 3",
    isAdult: true,
    startYear: 1995,
    endYear: 2001,
    runTimeMinutes: 45,
    genre: "Comedy"
  },
  {
    titleId: "4",
    titleType: "Movie 4",
    primaryTitle: "Movie 4 Test",
    originalTitle : "Original Movie 4",
    isAdult: false,
    startYear: 2000,
    endYear: 2014,
    runTimeMinutes: 99,
    genre: "Horrer"
  },
  {
    titleId: "5",
    titleType: "Movie 44",
    primaryTitle: "Movie 44 Test",
    originalTitle : "Original Movie 44",
    isAdult: true,
    startYear: 2000,
    endYear: 2005,
    runTimeMinutes: 98,
    genre: "Thriller"
  }
];

function replaceAll(str, find, replace) {
  return str.replace(new RegExp(find, 'g'), replace);
}

//This would be performed on the server in a real app. Just stubbing in.
const generateId = (movie) => {
  return replaceAll(movie.titleType, ' ', '-');
};

class MovieApi {
  static getAllMovies() {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve(Object.assign([], movies));
      }, delay);
    });
  }

  static getFilteredMovies(title) {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        let filteredMovies = [];
        if (title) {
          filteredMovies = movies.filter(a => a.titleType.indexOf(title) > -1);
        }
        else {
          reject(`Title cannot be empty`);
        }
        resolve(Object.assign([], filteredMovies));
      }, delay);
    });
  }

  static saveMovie(movie) {
    movie = Object.assign({}, movie); // to avoid manipulating object passed in.
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        // Simulate server-side validation
        const minMovieTitleLength = 1;
        if (movie.titleType.length < minMovieTitleLength) {
          reject(`Title must be at least ${minMovieTitleLength} characters.`);
        }

        if (movie.titleId) {
          const existingMovieIndex = movies.findIndex(a => a.titleId == movie.titleId);
          movies.splice(existingMovieIndex, 1, movie);
        } else {
          //Just simulating creation here.
          //The server would generate ids and watchHref's for new movies in a real app.
          //Cloning so copy returned is passed by value rather than by reference.
          movie.titleId = generateId(movie);
          movies.push(movie);
        }

        resolve(movie);
      }, delay);
    });
  }

  static removeMovie(movieId) {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        const indexOfMovieToDelete = movies.findIndex(movie => {
          return movie.titleId === movieId;
        });
        movies.splice(indexOfMovieToDelete, 1);
        resolve(movieId);
      }, delay);
    });
  }
}

export default MovieApi;
