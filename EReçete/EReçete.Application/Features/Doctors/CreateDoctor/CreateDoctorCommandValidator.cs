using FluentValidation;

namespace EReçete.Application.Features.Doctors.CreateDoctor
{
    public sealed class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("Doktor adı boş olamaz")
                .MaximumLength(50).WithMessage("Doktor adı en fazla 50 karakter olabilir");
            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Doktor soyadı boş olamaz")
                .MaximumLength(50).WithMessage("Doktor soyadı en fazla 50 karakter olabilir");
            RuleFor(p => p.DiplomaNumber)
                .NotEmpty().WithMessage("Diploma numarası boş olamaz")
                .MaximumLength(20).WithMessage("Diploma numarası en fazla 20 karakter olabilir");
            RuleFor(p => p.Branch)
                .NotEmpty().WithMessage("Branş boş olamaz")
                .MaximumLength(100).WithMessage("Branş en fazla 100 karakter olabilir");
        }
    }
}
