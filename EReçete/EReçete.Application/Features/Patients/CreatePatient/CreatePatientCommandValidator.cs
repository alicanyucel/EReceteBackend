using FluentValidation;

namespace EReçete.Application.Features.Patients.CreatePatient
{
    public sealed class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("Hasta adı boş olamaz")
                .MaximumLength(50).WithMessage("Hasta adı en fazla 50 karakter olabilir");
            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Hasta soyadı boş olamaz")
                .MaximumLength(50).WithMessage("Hasta soyadı en fazla 50 karakter olabilir");
            RuleFor(p => p.IdentityNumber)
                .NotEmpty().WithMessage("TC kimlik numarası boş olamaz")
                .Length(11).WithMessage("TC kimlik numarası 11 karakter olmalıdır");
            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("Doğum tarihi boş olamaz");
            RuleFor(p => p.PhoneNumber)
                .MaximumLength(20).WithMessage("Telefon numarası en fazla 20 karakter olabilir");
        }
    }
}
