import React, {PropTypes} from 'react';
import {Link} from 'react-router';

const MovieListRow = ({movie}) => {
    return (
        <tr>
            <td>&nbsp;</td>
            <td><Link to={`/movie/` + movie.titleId}>{movie.titleType}</Link></td>
            <td>{movie.primaryTitle}</td>
            <td>{movie.originalTitle}</td>
            <td>{movie.isAdult.toString()}</td>
            <td>{movie.startYear}</td>
            <td>{movie.endYear}</td>
            <td>{movie.runTimeMinutes}</td>
            <td>{movie.genre}</td>
        </tr>
    );
};

MovieListRow.propTypes = {
    movie: PropTypes.object.isRequired
};

export default MovieListRow;