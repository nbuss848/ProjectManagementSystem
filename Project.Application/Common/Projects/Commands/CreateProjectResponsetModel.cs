using FluentValidation.Results;
using System;

namespace Project.Application.Common.ViewModels
{
    public class CreateProjectResponseModel
    {
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ValidationResult Errors { get; set; }
    }
}