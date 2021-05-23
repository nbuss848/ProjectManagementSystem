using AutoMapper;
using MediatR;
using Project.Application.Common.Commands;
using Project.Application.Common.Queries;
using Project.Application.Common.ViewModels;
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
            var projects = _mediator.Send(new GetProjectsQuery());
            foreach (var project in projects.Result.ProjectViewModels)
            {
                var item = new ProjectViewListing();
                item.BindVM(project);

                flpMain.Controls.Add(item);
            }
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
