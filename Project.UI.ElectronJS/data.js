const axios = require('axios');

axios.get('https://localhost:44360/API/PMC')
    .then(response => {
        console.log(response.data.url);
        console.log(response.data.explanation);
    })
    .catch(error => {
        console.log(error);
    });