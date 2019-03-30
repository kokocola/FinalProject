
/* eslint-disable import/default */
import 'babel-polyfill';
import React from 'react';
import { render } from 'react-dom';
import { Router, browserHistory } from 'react-router';
import { Provider } from 'react-redux';
import routes from './routes';
import './styles/styles.css';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import configureStore from './store/configureStore';
import {loadCourses} from './actions/courseActions';
import {loadAuthors} from './actions/authorActions';
import '../node_modules/toastr/build/toastr.min.css';
import { loadMovies } from './actions/movieActions';

const store = configureStore();
store.dispatch(loadCourses()); //load courses in beginning
store.dispatch(loadAuthors()); //load authors in beginning
store.dispatch(loadMovies());

render(
    <Provider store={store}>
        <Router history={browserHistory} routes={routes} />
    </Provider>,
    document.getElementById('app')
);
