namespace Hospitality.Web.Mapper
{
    public class UpdatePatientDTOProfile : Profile
    {
        public UpdatePatientDTOProfile()
            => CreateMap<AppointDoctorToPatientModel, UpdateAssinedDoctorOfPatientDTO>();
    }
}
