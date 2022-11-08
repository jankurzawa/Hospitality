namespace Hospitality.Web.Mapper
{
    public class PatientDataCheckUpViewModelProfile : Profile
    {
        public PatientDataCheckUpViewModelProfile()
        {
            CreateMap<PatientDataCheckUpViewModel, CreateExaminationDto>()
                .ForMember(eid => eid.ExaminationTypeId, src => src.MapFrom(pdcvm => pdcvm.ChosenExaminationId))
                .ForMember(eid => eid.PatientId, src => src.MapFrom(pdcvm => pdcvm.PatientId));
            CreateMap<PatientDataCheckUpViewModel, NewCheckUpDTO>()
                .ForMember(ncd => ncd.IdPatient, src => src.MapFrom(pdcvm => pdcvm.PatientId))
                .ForMember(ncd => ncd.PatientPesel, src => src.MapFrom(pdcvm => pdcvm.PatientPesel))
                .ForMember(ncd => ncd.IdDoctor, src => src.MapFrom(pdcvm => pdcvm.DoctorId))
                .ForMember(ncd => ncd.Description, src => src.MapFrom(pdcvm => pdcvm.Description))
                .ForMember(ncd => ncd.IsInsured, src => src.MapFrom(pdcvm => pdcvm.IsInsured));
        }
    }
}
