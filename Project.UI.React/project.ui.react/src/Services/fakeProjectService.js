export const Projects = [
    { 
        Id : 1,
        Name: "Home Project",
        Description: "A project that help keep track of everything around the house",
        NumberOfTasks : 4
    }
  ];
  
  export function getProjects() {
    return Projects.filter(g => g);
  }
  