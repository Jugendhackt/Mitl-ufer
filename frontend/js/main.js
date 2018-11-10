function usersGetAllGet() {
  let didTimeOut = false;

  return new Promise(function(resolve, reject) {
      const timeout = setTimeout(function() {
          didTimeOut = true;
          reject(new Error('Request timed out'));
      }, 2500);

      fetch('http://172.22.42.100:8080/users/getAll')
      .then(function(response) {
          clearTimeout(timeout);
          if(!didTimeOut) {
              resolve(response);
          }
      })
      .catch(function(err) {
          if(didTimeOut) return;
          // Reject with other error, besides timeout
          reject(err);
      });
  })
  .then(function(response) {
      if (response.ok) {
        return response.json();
      } else {
        return Promise.reject(Error('error'));
      }
  }).then(function(data){
    return data;
  })
  .catch(function(err) {
      console.log('error: ', err);
  });
}
