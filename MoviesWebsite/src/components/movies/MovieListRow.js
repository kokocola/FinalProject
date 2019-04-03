import React, {PropTypes} from 'react';
import {Link} from 'react-router';

const MovieListRow = ({movie}) => {
    return (
        <tr>
            <td>&nbsp;</td>
            <td>{movie.titleType}</td>
            <td><Link to={`/movie/` + movie.titleId}>{movie.primaryTitle}</Link></td>
            <td>{movie.originalTitle}</td>
            <td>{movie.isAdult.toString()}</td>
            <td>{movie.startYear}</td>
            <td>{movie.endYear}</td>
            <td>{movie.runtimeMinutes}</td>
            <td>{movie.genres}</td>
        </tr>
    );
};

MovieListRow.propTypes = {
    movie: PropTypes.object.isRequired
};

export default MovieListRow;