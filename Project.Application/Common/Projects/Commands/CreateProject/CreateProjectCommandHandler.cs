using FluentValidation;
using MediatR;
using Project.Application.Common.Interfaces;
using Project.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Common.Commands
{
    public class CreateProjectCommand : IRequest<CreateProjectResponseModel>
    {
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public DateTime? FrequencyStartDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Classification { get; internal set; }
        public DateTime? DueDate { get; internal set; }
        public string ProjectImage { get; internal set; }
        public DateTime? CreatedDate { get; set; }
    }
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectResponseModel>
    {
        private readonly IApplicationDbContext _context;
        
        public CreateProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateProjectResponseModel> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var result = new CreateProjectResponseModel()
            {
             
            };

            CreateProjectValidator validationRules = new CreateProjectValidator();
            var results = validationRules.Validate(request);
            if (results.IsValid)
            {
                var project = new Domain.MySql.Project()
                {
                    ProjectId = 0,
                    CreatedDate = DateTime.Now,
                   // Description = request.Description,
                    Name = request.Name,
                    Size = request.Size,
                    Priority = request.Priority,
                    //Classification = request.Classification,
                    DueDate = request.DueDate,
                    ProjectImage = request.ProjectImage,
                    Status = _context.Statuscodes.Where(x => x.Name.ToLower() == request.Status).FirstOrDefault()
                };

                result = new CreateProjectResponseModel()
                {
                    CreatedDate = DateTime.Now,
                    Description = project.Name,
                    ProjectId = project.ProjectId
                };

                _context.Projects.Add(project);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                result = new CreateProjectResponseModel() {
                    Errors = results
                };
            }

            return result;
        }
    }
    public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.Size).GreaterThan(0);
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
