using MediatR;
using Project.Application.Common.Commands;
using Project.Application.Common.Interfaces;
using Project.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.WinForms.Controllers
{
    public class WindowsController : IController
    {
        private readonly IMediator _mediator;
        public WindowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // HttpPost
        public void AddTask(ProjectTaskCreateViewModel vm)
        {
            _mediator.Send(new CreateTaskForProjectCommand() { model = vm });
        }
    }
}
