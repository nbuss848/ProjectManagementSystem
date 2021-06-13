var axios = require('axios');

var config = {
    method: 'get',
    url: 'https://localhost:5001/API/PMC',
    headers: {
        mode : 'cors'
    }
};



const videoSelectBtn = document.getElementById('videoSelectBtn');
videoSelectBtn.onclick = getVideoSources;

// Get the available video sources
async function getVideoSources() {
    axios(config)
        .then(function (response) {
            console.log(JSON.stringify(response.data));
        })
        .catch(function (error) {
            console.log(error);
        });
}
