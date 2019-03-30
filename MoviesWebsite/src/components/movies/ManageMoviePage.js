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
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.movie.id != nextProps.movie.id) {
            this.setState({movie:Object.assign({}, nextProps.movie)});
        }
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

        if (this.state.movie.title.length < 3) {
            errors.title = 'Title must be at least 3 characters.';
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

    render() {
        return (
            <MovieForm
                onChange={this.updateMovieState}
                onSave={this.saveMovie}
                errors={this.state.errors}
                movie={this.state.movie}
                saving={this.state.saving}
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
    const movie = movies.filter(movie => movie.id == id);
    return (movie.length) ? movie[0] : null;
}

//react is updating the form to show up new results
function mapStateToProps(state, ownProps) {

    const movieId = ownProps.params.id;

    let movie = {
        id: '',
        watchHref:'',
        title:'',
        authorId:'',
        length:'',
        category: ''
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