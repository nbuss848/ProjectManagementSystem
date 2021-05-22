using AutoMapper;
using MediatR;
using Project.Application.Common.Projects.Commands;
using Project.Application.Common.Projects.Commands.Subtask;
using Project.Application.Common.Projects.Queries;
using Project.Application.Common.Queries;
using Project.Web.Models;
using Project.Web.Models.SubTasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinForms
{
    public partial class MainForm : Form
    {
        private readonly IMediator _mediator;
        public MainForm(IMediator mediator)
        {
            _mediator = mediator;

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            ProjectViewListing[] items = new ProjectViewListing[10];

            var projects = _mediator.Send(new GetProjectsQuery());
            foreach (var project in projects.Result.ProjectViewModels)
            {
                items[0] = new ProjectViewListing();
                items[0].BindVM(project);

                flpMain.Controls.Add(items[0]);
            }

            //dgvProjects.DataSource = projects.Result.ProjectViewModels;
            //dgvProjects.Refresh();
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Domain.Entities.Project, ProjectViewModel>();
                CreateMap<ProjectCreateModel, CreateProjectRequestModel>();
                CreateMap<SubTaskCreateViewModel, CreateSubTaskCommand>();
            }
        }

    }
}
