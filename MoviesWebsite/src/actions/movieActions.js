import * as types from './actionTypes';
import movieApi from '../api/mockMovieApi';
import {beginAjaxCall, AjaxCallError} from './ajaxStatusActions';

export function loadMoviesSuccess(movies) {
    return { type: types.LOAD_MOVIES_SUCCESS, movies};
}

export function createMovieSuccess(movie) {
    return { type: types.CREATE_MOVIE_SUCCESS, movie};
}

export function updateMovieSuccess(movie) {
    return { type: types.UPDATE_MOVIE_SUCCESS, movie};
}

export function removeMovieSuccess(id) {
    return { type: types.REMOVE_MOVIE_SUCCESS, id};
}

export function searchMovieSuccess(movies) {
    return { type: types.SEARCH_MOVIE_SUCCESS, movies};
}

export function loadMovies() { //this gets called onload //https://github.com/reduxjs/redux-thunk
    return function(dispatch) {
        dispatch(beginAjaxCall());
        return movieApi.getAllMovies().then(movies => {
            dispatch(loadMoviesSuccess(movies));
        }).catch(error => {
            dispatch(AjaxCallError());
            throw(error);
        });
    };
}

export function searchMovies(title) { //this gets called onload //https://github.com/reduxjs/redux-thunk
    return function(dispatch) {
        dispatch(beginAjaxCall());
        return movieApi.getFilteredMovies(title).then(movies => {
            dispatch(searchMovieSuccess(movies));
        }).catch(error => {
            dispatch(AjaxCallError());
            throw(error);
        });
    };
}

export function saveMovie(movie) { //this gets called onload
    return function(dispatch, getState) {
        dispatch(beginAjaxCall());
        return movieApi.saveMovie(movie).then(savedMovie => {
            movie.titleId ? dispatch(updateMovieSuccess(savedMovie)) : dispatch(createMovieSuccess(savedMovie));
        }).catch(error => {
            dispatch(AjaxCallError());
            throw(error);
        });
    };
}

export function removeMovie(id) {
    return function(dispatch, getState) {
        dispatch(beginAjaxCall());
        return movieApi.removeMovie(id).then(id => {
            dispatch(removeMovieSuccess(id));
        }).catch(error => {
            dispatch(AjaxCallError());
            throw(error);
        });
    };
}