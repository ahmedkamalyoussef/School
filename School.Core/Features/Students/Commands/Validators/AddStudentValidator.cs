using FluentValidation;
using School.Core.Features.Students.Commands.Models;
using School.Services.Abstracts;

namespace School.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;

        public AddStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidations();
            ApplyCustomValidations();
        }

        public void ApplyValidations()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} cant be empty")
                .NotNull().WithMessage("{PropertyName} cant be null");
        }
        public void ApplyCustomValidations()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsExist(key))
                .WithMessage("{PropertyName} already exist");
        }
    }
}
