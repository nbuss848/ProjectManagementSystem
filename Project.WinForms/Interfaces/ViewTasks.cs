using MediatR;
using Project.Application.Common.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinForms.Interfaces
{
    public partial class frmViewTasks : Form
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _provider;
        public int ProjectId { get; set; }

        public frmViewTasks(IMediator mediator, IServiceProvider provider)
        {
            InitializeComponent();

            _mediator = mediator;
            _provider = provider;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewTasks_Load(object sender, EventArgs e)
        {
            var viewmodel = _mediator.Send(new GetProjectTasksByProjectIdQuery(ProjectId));

            lbHeader.Text = viewmodel.Result.Name;
            lstTasks.DataSource = viewmodel.Result.TaskList.ToList();
            lstTasks.DisplayMember = "Name";
            lstTasks.Refresh();
           
            //foreach (var item in viewmodel.Result.TaskList)
            //{
            //    var i = new ListViewItem(item.Name);
            //    lstTasks.Items.Add(i);
            //}
        }
    }
}
