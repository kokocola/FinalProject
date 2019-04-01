import React, {PropTypes} from 'react';
import MovieListRow from './MovieListRow';

const MovieList = ({movies}) => {
    return (
        <table className="table">
            <thead>
                <tr>
                    <th>&nbsp;</th>
                    <th>Title Type</th>
                    <th>Primary Title</th>
                    <th>Original Title</th>
                    <th>Is Adult</th>
                    <th>Start Year</th>
                    <th>End Year</th>
                    <th>Minutes</th>
                    <th>Genre</th>
                </tr>
            </thead>
            <tbody>
                {movies.map(movie =>
                    <MovieListRow key={movie.titleId} movie={movie}/>
                )}
            </tbody>
        </table>
    );
};

MovieList.propTypes = {
    movies: PropTypes.array.isRequired
};

export default MovieList;