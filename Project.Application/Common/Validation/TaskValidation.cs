using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Application.Common.Validation
{
    public class TaskValidation : AbstractValidator<Project.Domain.Entities.Task>
    {
        public TaskValidation()
        {
            RuleFor(x => x.Size).GreaterThan(0);
        }
    }
}
