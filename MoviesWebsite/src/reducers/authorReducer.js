import * as types from '../actions/actionTypes';
import initialState from './inititalState';

export default function authorReducer(state = [], action) {
    switch(action.type) {
        case types.LOAD_AUTHORS_SUCCESS:
            return action.authors;
        default:
            return state;
    }
}