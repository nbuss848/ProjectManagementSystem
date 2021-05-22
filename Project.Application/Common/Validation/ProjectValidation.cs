using FluentValidation;
using Project.Application.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Application.Common.Validation
{
    public class ProjectValidation : AbstractValidator<CreateProjectRequestModel>
    {
        public ProjectValidation()
        {
            RuleFor(x => x.Size).GreaterThan(0);
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
