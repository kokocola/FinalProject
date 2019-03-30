import {createStore, applyMiddleware} from 'redux';
import rootReducer from  '../reducers';
import thunk from 'redux-thunk';

export default function configureStore(initialState) {
    return createStore(
        rootReducer,
        initialState,
        //the reduxImmutableStateInvariant is used to check that state isn't changed but it is a new state
        applyMiddleware(thunk)
    );
}