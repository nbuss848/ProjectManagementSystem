using Microsoft.Extensions.DependencyInjection;
using Project.Application.Common.Queries;
using Project.Application.Common.ViewModels;
using Project.WinForms.Interfaces;
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
    public partial class ProjectViewListing : UserControl
    {
        public ProjectViewModel VM { get; set; }
        private readonly IServiceProvider _services;

        public ProjectViewListing(IServiceProvider serviceProvider)
        {
            _services = serviceProvider;
            VM = new ProjectViewModel();

            InitializeComponent();
        }

        public void BindVM(ProjectViewModel vm)
        {
            VM = vm;
            lbName.Text = vm.Name;
            Description.Text = vm.Description;
            NumberOfTasks.Text = vm.NumberOfTasks.ToString();
            this.Refresh();
        }

        private void btAddTask_Click(object sender, EventArgs e)
        {
            //var form = new AddTask() { ProjectId = VM.ProjectId };

            var main = _services.GetRequiredService<AddTask>();
            main.ProjectId = VM.ProjectId;

            main.Show();
        }

        private void ProjectView_Load(object sender, EventArgs e)
        {

        }

        private void btViewTask_Click(object sender, EventArgs e)
        {
            var main = _services.GetRequiredService<frmViewTasks>();
            main.ProjectId = VM.ProjectId;

            main.Show();
        }
    }
}
