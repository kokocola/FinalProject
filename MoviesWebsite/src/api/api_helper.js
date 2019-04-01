export function make_api_get_call(host, controller) {
    fetch(`${host}${controller}`)
    .then((response) => { return response.json(); })
    .then((data) => {
      console.log(data);
      return data;
    });
  }

  export function make_api_post_call(host, controller) {
    fetch(`${host}${controller}`, { mode: 'no-cors', method: 'POST' })
      .then(
        (result) => {
            console.log(result);
            return result;
        },
        (error) => {
          return error;
        }
      )
  }