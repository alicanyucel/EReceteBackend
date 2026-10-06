using FluentValidation;

namespace EReçete.Application.Features.Medications.CreateMedication
{
    public sealed class CreateMedicationCommandValidator : AbstractValidator<CreateMedicationCommand>
    {
        public CreateMedicationCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("İlaç adı boş olamaz")
                .MaximumLength(100).WithMessage("İlaç adı en fazla 100 karakter olabilir");
            RuleFor(p => p.Barcode)
                .NotEmpty().WithMessage("Barkod boş olamaz")
                .MaximumLength(50).WithMessage("Barkod en fazla 50 karakter olabilir");
            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir");
        }
    }
}
