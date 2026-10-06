using AutoMapper;
using EReçete.Application.Features.Doctors.CreateDoctor;
using EReçete.Application.Features.Doctors.UpdateDoctor;
using EReçete.Application.Features.Medications.CreateMedication;
using EReçete.Application.Features.Medications.UpdateMedication;
using EReçete.Application.Features.Patients.CreatePatient;
using EReçete.Application.Features.Patients.UpdatePatient;
using EReçete.Domain.Entities;

namespace EReçete.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMedicationCommand, Medication>().ReverseMap();
            CreateMap<UpdateMedicationCommand, Medication>().ReverseMap();
            CreateMap<CreateDoctorCommand, Doctor>().ReverseMap();
            CreateMap<UpdateDoctorCommand, Doctor>().ReverseMap();
            CreateMap<CreatePatientCommand, Patient>().ReverseMap();
            CreateMap<UpdatePatientCommand, Patient>().ReverseMap();
        }
    }
}
