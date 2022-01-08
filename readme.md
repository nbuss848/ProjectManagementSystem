# Project Management System #
### What?
Yet another project management tool that hopes to set expectations right in the first place 
and report on true project progress. 

### How?
Display task completion dates and automatically add tasks that were completed and the length of time they were worked on. 
As well as a general scale of the task which drives the projection system.


## Goals 
_by priority high -> low_
- [ ] Set up clean architecture example of a real system
- [ ] Show that one feature can be reused by multiple different front-end interfaces
- [ ] Create system that allows easy maintainence of to be done tasks.
- [ ] Show all tasks overlapping each-other with a projected completed date based off of previous data.

## Roadmap
- [ ] Create project and link tasks to those projects. Create tasks that can link to parent tasks.
- [ ] Create React interface
- [ ] Create data-visualization of open and completed tasks in all projects that are created in the system. (Gantt chart?)

## Setup
Download XAMPP (recommend version 7.X.X) and run MySql scripts to setup database (```.\_MySql Scripts```).
Set connection string to your localhost in each project appsettings.json file.
*Example:* ```"MySql" = "Server=localhost;Database=PMS;uid=PMS;PWD=root"```
Make sure to start Apache and MySql in XAMPP and you should be good to start using the app.

#### Issues
- [ ] Electron desktop environment doesn't seem to work - unknown source of the bug.
- [ ] Since tasks can now link to other tasks the task building system can now by simplified.
- [ ] Xamarin project not loaded due to resources

## Technologies
* Mediator
* Fluent Validation
* Auto mapper
* ef core
* postgres database
* MySql database
* electron ui
* windows form ui
* blazor with electron or web site
* console example with DI
* Xamarin UI (not working yet)
