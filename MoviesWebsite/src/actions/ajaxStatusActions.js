import * as types from './actionTypes';

export function beginAjaxCall() {
    return {type: types.BEGIN_AJAX_CALL};
}

export function AjaxCallError() {
    return {type: types.AJAX_CALL_ERROR};
}
