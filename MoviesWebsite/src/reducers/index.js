import {combineReducers} from 'redux';
import courses from './courseReducer';
import movies from './movieReducer';
import authors from './authorReducer';
import ajaxCallsInProgress from './ajaxStatusReducer';

const rootReducer = combineReducers({
    courses,
    movies,
    authors,
    ajaxCallsInProgress
});

export default rootReducer;