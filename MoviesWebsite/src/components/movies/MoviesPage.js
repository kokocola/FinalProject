import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import * as movieActions from '../../actions/movieActions';
import { bindActionCreators } from 'redux';
import MovieList from './MovieList';
import {browserHistory} from 'react-router';

class MoviesPage extends React.Component {

    constructor(props, context) {
        super(props, context);
        this.redirectToAddMoviePage = this.redirectToAddMoviePage.bind(this);
    }

    movieRow(movie, index) {
        return <div key={index}>{movie.title}</div>;
    }

    redirectToAddMoviePage(event) {
        browserHistory.push('/movie');
    }

    render() {
        const {movies} = this.props;

        return (
            <div>
                <h1>Movies Page</h1>
                <input
                    type="submit"
                    value="Add Movie"
                    className="btn btn-primary"
                    onClick={this.redirectToAddMoviePage}/>
                <MovieList movies={movies}/>
            </div>
        );
    }
}

MoviesPage.propTypes = {
    movies: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
};

//react is updating the form to show up new results
function mapStateToProps(state, ownProps) {
    return {
        movies: state.movies
    };
}

//react is matching the creating of the action code to the code
function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(movieActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(MoviesPage);