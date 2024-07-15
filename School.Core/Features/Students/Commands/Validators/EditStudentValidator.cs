using FluentValidation;
using School.Core.Features.Students.Commands.Models;
using School.Services.Abstracts;

namespace School.Core.Features.Students.Commands.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;

        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            //ApplyValidations();
            ApplyCustomValidations();
        }

        public void ApplyValidations()
        {
        }
        public void ApplyCustomValidations()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, name, CancellationToken) => !await _studentService.IsExist(name, model.StudID))
                .WithMessage("{PropertyName} already exist");
        }
    }
}
