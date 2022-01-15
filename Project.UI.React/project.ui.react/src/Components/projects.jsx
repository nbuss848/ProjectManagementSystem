import React, { Component } from 'react';
import * as projectAPI from "../Services/fakeProjectService";
import Project from './project';

class ViewProjects extends Component {
    state = { projects: projectAPI.getProjects() } 
    render() { 
        return (
            <div>
            {this.state.projects.map( p => 
            <Project project={p}>

            </Project>)}
            </div>
        );
    }
}
 
export default ViewProjects;