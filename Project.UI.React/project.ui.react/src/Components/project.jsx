import React, { Component } from "react";

class Project extends React.Component {
    render() {
        return <div>

       <div className="row">
       <div className="col-md-6 col-sm-12 text-center">
            <div className="card">
                {/* <img className="card-img-top" src="..." alt="Card image cap"> */}
                <div className="card-body">
                    <h5 className="card-title">{this.props.project.Name}</h5>
                    <p className="card-text">{this.props.project.Description}</p>
                    <p className="card-text">Number Of Tasks: {this.props.project.NumberOfTasks}</p>
                    <a onClick="ProjectTask" 
                    // asp-action="AddTask" asp-route-projectId="@project.ProjectId" 
                       className="btn btn-primary m-2">Add Task</a>
                    <a onClick="ProjectTask" 
                       className="btn btn-secondary m-2">View Tasks</a>
                </div>
            </div>
        </div>
       </div>

        </div>;
    }
}

export default Project;