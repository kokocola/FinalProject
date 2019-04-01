import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as movieActions from '../../actions/movieActions';
import MovieForm from './MovieForm';
import toastr from 'toastr';

export class ManageMoviePage extends React.Component {

    constructor(props, context) {
        super(props, context);
        this.state = {
            movie: Object.assign({}, this.props.movie),
            errors: {},
            saving: false
        };
        this.updateMovieState = this.updateMovieState.bind(this);
        this.saveMovie = this.saveMovie.bind(this);
        this.deleteMovie = this.deleteMovie.bind(this);
    }

    componentWillReceiveProps(nextProps) {
        if (nextProps.movie && (this.props.movie.titleId != nextProps.movie.titleId)) {
            this.setState({movie:Object.assign({}, nextProps.movie)});
        }
    }

    deleteMovie(event) {
        event.preventDefault();
        this.props.actions.removeMovie(this.state.movie.titleId)
        .then(() => {
            this.redirectDeleted();
        })
        .catch((error) => {
            toastr.error('Movie Saving Failed: ' + error);
        });
    }

    updateMovieState(event) {
        const field = event.target.name;
        let movie = this.state.movie;
        movie[field] = event.target.value;
        return this.setState({movie:movie});
    }

    movieFormIsValid() {
        let formIsValid = true;
        let errors = {};

        if (this.state.movie.titleType.length < 3) {
            errors.titleType = 'Title must be at least 3 characters.';
            formIsValid = false;
        }

        this.setState({errors:errors});
        return formIsValid;
    }

    saveMovie(event) {
        event.preventDefault();

        if (!this.movieFormIsValid()) {
            return;
        }
        this.setState({saving:true});
        this.props.actions.saveMovie(this.state.movie)
        .then(() => {
            this.redirect();
        })
        .catch((error) => {
            toastr.error('Movie Saving Failed: ' + error);
        })
        .finally(() => {
            this.setState({saving:false});
        });
    }

    redirect() {
        toastr.success('Movie Saved');
        this.context.router.push('/movies');
    }

    redirectDeleted() {
        toastr.success('Movie Deleted');
        this.context.router.push('/movies');
    }

    render() {
        return (
            <MovieForm
                onChange={this.updateMovieState}
                onSave={this.saveMovie}
                errors={this.state.errors}
                movie={this.state.movie}
                saving={this.state.saving}
                onDelete={this.deleteMovie}
            />
        );
    }
}

ManageMoviePage.propTypes = {
    movie: PropTypes.object.isRequired,
    actions: PropTypes.object.isRequired
};

//this have to be always after class
ManageMoviePage.contextTypes = {
    router: PropTypes.object
};

function getMovieById(movies, id) {
    const movie = movies.filter(movie => movie.titleId === id);
    return (movie.length) ? movie[0] : null;
}

//react is updating the form to show up new results
function mapStateToProps(state, ownProps) {

    const movieId = ownProps.params.id;

    let movie = {
        titleId: '',
        titleType:'',
        primaryTitle:'',
        originalTitle:'',
        isAdult:false,
        startYear: '',
        endYear: '',
        runtimeMinutes: '',
        genres: ''
    };

    if (movieId && state.movies.length > 0) {
        movie = getMovieById(state.movies, movieId);
    }

    return {
        movie: movie
    };
}

//react is matching the creating of the action code to the code
function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(movieActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(ManageMoviePage);