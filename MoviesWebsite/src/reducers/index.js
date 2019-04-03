import {combineReducers} from 'redux';
import movies from './movieReducer';
import ajaxCallsInProgress from './ajaxStatusReducer';

const rootReducer = combineReducers({
    movies,
    ajaxCallsInProgress
});

export default rootReducer;