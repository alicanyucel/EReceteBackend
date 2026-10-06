using FluentValidation;

namespace EReçete.Application.Features.Medications.UpdateMedication
{
    public sealed class UpdateMedicationCommandValidator : AbstractValidator<UpdateMedicationCommand>
    {
        public UpdateMedicationCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id boş olamaz");
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
