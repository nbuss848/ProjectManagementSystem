import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import ViewProjects from './Components/projects';
import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.css';
import logo from './logo.svg';
ReactDOM.render(
  <React.StrictMode>
    {/* <App /> */}
    
    <div className='container'>
        <div className='row'>
      <div className='col text-center'>
          <h1> React <img style={{width:"50px", height:"50px"}} src={logo} className="App-logo" alt="logo" />   </h1>
        </div>
      </div>
    <div className="row">
    <div className='col'>
            <div className="col-md-12">
                <h1>Projects 
                 </h1>
                <a onClick="ProjectCreate" className="btn btn-outline-primary">Create New Project</a>
                <p>&nbsp;</p>
            </div>
        </div>
    <ViewProjects/>
    </div>
    </div>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
