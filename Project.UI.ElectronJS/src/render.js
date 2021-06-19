var axios = require('axios');

var config = {
    method: 'get',
    //url: 'https://localhost:5001/API/PMC',
    url: 'http://localhost:30213/API/PMC',
    headers: {
        mode : 'cors'
    }
};

//const template = "<div class="row">    
//@foreach(var project in Model.ProjectViewModels)
//{
//    <div class="col-md-6 col-sm-12 text-center">
//        <div class="card">
//            @*<img class="card-img-top" src="..." alt="Card image cap">*@
//                <div class="card-body">
//                    <h5 class="card-title">@project.Name</h5>
//                    <p class="card-text">@project.Description</p>
//                    <p class="card-text">Number Of Tasks: @project.NumberOfTasks</p>
//                    <a asp-controller="ProjectTask" asp-action="AddTask" asp-route-projectId="@project.ProjectId"
//                        class="btn btn-primary">Add Task</a>
//                    <a asp-controller="ProjectTask" asp-action="Index" asp-route-projectId="@project.ProjectId"
//                        class="btn btn-secondary">View Tasks</a>
//                </div>
//            </div>
//        </div>
//    }
//</div>
//"


const projects = document.getElementById('projects');

//videoSelectBtn.onclick = getVideoSources;

window.addEventListener('load', (event) => {
    getVideoSources();
});

// Get the available video sources
async function getVideoSources() {
    axios(config)
        .then(function (response) {
            var html = "";
            for (var i = 0; i < response.data.result.projectViewModels.length; i++) {                
                html += BuildHtml(response.data.result.projectViewModels[i]);
            }
            
            projects.innerHTML = html;
        })
        .catch(function (error) {
            projects.innerHTML = "<p class='text-danger'>Couldn't retrieve projects from API</p>";
        });
}

function BuildHtml(projectJSON) {
    var result =
    '<div class="col-md-6 col-sm-12 text-center py-2">'
        + '<div class="card">'
          //  + '<img class="card-img-top" src="..." alt="Card image cap">'
                + '<div class="card-body">'
                    + '<h5 class="card-title">'+ projectJSON.name +'</h5>'
                    + '<p class="card-text">' + projectJSON.description +'</p>'
        + '<p class="card-text">Number Of Tasks: ' + projectJSON.numberOfTasks + '</p>'
                    + '<a class="btn btn-primary text-white">Add Task</a>'
                    + '<a class="btn btn-secondary text-white">View Tasks</a>'
                + '</div>'                       
                      + '</div>'
            + '</div>'

            return result;
}