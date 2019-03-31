import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import * as movieActions from '../../actions/movieActions';
import { bindActionCreators } from 'redux';
import MovieList from './MovieList';
import MovieList2 from './MovieList2';
import {browserHistory} from 'react-router';
import _ from 'lodash';
import SearchBar from '../common/SearchBar';
import toastr from 'toastr';

class MoviesPage extends React.Component {

    constructor(props, context) {
        super(props, context);
        this.redirectToAddMoviePage = this.redirectToAddMoviePage.bind(this);
        this.updateTitleState = this.updateTitleState.bind(this);
        this.state = {
            errors: {},
            searchTitle: ''
        };

        this.searchMovies = this.searchMovies.bind(this);
    }

    redirectToAddMoviePage(event) {
        browserHistory.push('/movie');
    }

    updateTitleState(event) {
        const field = event.target.value;
        return this.setState({searchTitle:field});
    }

    searchMovies(event) {
        event.preventDefault();
        this.props.actions.searchMovies(this.state.searchTitle)
        .then(() => {
            toastr.success('Search Completed');
        })
        .catch((error) => {
            toastr.error('Movie Saving Failed: ' + error);
        });
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
                    onClick={this.redirectToAddMoviePage} />
                <SearchBar
                    name="search"
                    label="Search Movies List"
                    placeholder="Search"
                    onChange={this.updateTitleState}
                    onClick={this.searchMovies}
                    value={this.searchTitle}
                />
                <MovieList movies={movies}/>
            </div>
        );
    }
}

MoviesPage.propTypes = {
    movies: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
};

//this have to be always after class
MoviesPage.contextTypes = {
    router: PropTypes.object
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