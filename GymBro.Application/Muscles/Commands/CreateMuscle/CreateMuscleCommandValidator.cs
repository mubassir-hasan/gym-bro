using FluentValidation;
using GymBro.Domain.ValueObjects;

namespace GymBro.Application.Muscles.Commands.CreateMuscle
{
    internal class CreateMuscleCommandValidator:AbstractValidator<CreateMuscleCommand>
    {
        public CreateMuscleCommandValidator()
        {
            RuleFor(r=>r.Title).NotEmpty().MaximumLength(Title.MaxLength);
        }
    }
}
