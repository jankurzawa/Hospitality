namespace Hospitality.Patient.API.Mapper
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<HospitalPatient, PatientDoctorViewDTO>();
            CreateMap<HospitalPatient, PatientReceptionistViewDTO>();
            CreateMap<PatientReceptionistViewDTO, PatientDoctorViewDTO>();
            CreateMap<PatientReceptionistViewDTO, HospitalPatient>();
            CreateMap<PatientDoctorViewDTO, HospitalPatient>();
            CreateMap<HospitalPatient, PatientNotificationDTO>();
            CreateMap<HospitalPatient, UpdateAssinedDoctorOfPatientDTO>().ReverseMap();
        }
    }
}