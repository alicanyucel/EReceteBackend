using FluentValidation;

namespace EReçete.Application.Features.Prescriptions.UpdatePrescription
{
    public sealed class UpdatePrescriptionCommandValidator : AbstractValidator<UpdatePrescriptionCommand>
    {
        public UpdatePrescriptionCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id boş olamaz");
            RuleFor(p => p.PrescriptionDate)
                .NotEmpty().WithMessage("Reçete tarihi boş olamaz");
            RuleFor(p => p.PatientId)
                .NotEmpty().WithMessage("Hasta seçilmelidir");
            RuleFor(p => p.DoctorId)
                .NotEmpty().WithMessage("Doktor seçilmelidir");
            RuleFor(p => p.Diagnosis)
                .NotEmpty().WithMessage("Teşhis boş olamaz")
                .MaximumLength(250).WithMessage("Teşhis en fazla 250 karakter olabilir");
            RuleFor(p => p.MedicationIds)
                .NotEmpty().WithMessage("Reçetede en az bir ilaç olmalıdır");
        }
    }
}
