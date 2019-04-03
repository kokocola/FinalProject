import axios from 'axios';

export function make_api_get_call(host, controller) {
    return axios.get(`${host}${controller}`);
  }

  export function make_api_post_call(host, controller) {
    fetch(`${host}${controller}`, { mode: 'no-cors', method: 'POST' })
      .then(
        (result) => {
            return result;
        },
        (error) => {
          return error;
        }
      )
  }