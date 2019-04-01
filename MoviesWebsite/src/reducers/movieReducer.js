import * as types from '../actions/actionTypes';
import initialState from './inititalState';

export default function movieReducer(state = [], action) {
    switch(action.type) {
        case types.LOAD_MOVIES_SUCCESS:
            return action.movies;
        case types.SEARCH_MOVIE_SUCCESS:
            return action.movies;
        case types.CREATE_MOVIE_SUCCESS:
            return [...state, Object.assign({}, action.movie)];
        case types.UPDATE_MOVIE_SUCCESS:
            return [...state.filter(movie => movie.titleId !== action.movie.titleId),
                    Object.assign({}, action.movie)];
        case types.REMOVE_MOVIE_SUCCESS:
            return [...state.filter(movie => movie.titleId !== action.id)];
        default:
            return state;
    }
}