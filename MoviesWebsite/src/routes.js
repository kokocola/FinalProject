import React from 'react';
import { Route, IndexRoute } from "react-router";
import App from './components/App';
import HomePage from './components/home/HomePage';
import AboutPage from './components/about/AboutPage';
import ManageMoviePage from './components/movies/ManageMoviePage'; //eslint-disable-line import/no-named-as-default
import MoviesPage from './components/movies/MoviesPage';

export default (
    <Route path="/" component={App}>
        <IndexRoute component={HomePage} />
        <Route path="about" component={AboutPage} />
        <Route path="movies" component={MoviesPage} />
        <Route path="movie" component={ManageMoviePage} />
        <Route path="movie/:id" component={ManageMoviePage} />
    </Route>
);