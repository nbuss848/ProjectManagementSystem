using MediatR;
using Project.Application.Common.Commands;
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
    public partial class AddTask : Form
    {
        public int ProjectId { get; set; }

        private IMediator _mediator;
        private ProjectTaskCreateViewModel _model;

        public AddTask(IMediator mediator)
        {
            _mediator = mediator;
            _model = new ProjectTaskCreateViewModel();

            InitializeComponent();
        }

        private void BindModel()
        {
            _model.Description = txDescription.Text;
            _model.FrequencyStartDate = DateTime.Parse(dateStartDate.Text);
            _model.ReminderDate = DateTime.Parse(dateReminder.Text);
            _model.Size = Convert.ToInt32(txSize.Text);
            _model.TaskId = 0;
            _model.ProjectId = ProjectId;
        }

        private void btAddTask_Click(object sender, EventArgs e)
        {
            BindModel();
            _mediator.Send(new CreateTaskForProjectCommand() { model = _model });
        }
    }
}
