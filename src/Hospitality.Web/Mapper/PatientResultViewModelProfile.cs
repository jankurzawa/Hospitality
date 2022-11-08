namespace Hospitality.Web.Mapper
{
    public class PatientResultViewModelProfile : Profile
    {
        public PatientResultViewModelProfile()
        {
            CreateMap<PatientResultViewModel, PatientReceptionistViewDTO>().ReverseMap()
                .ForMember(x => x.IdOfSelectedDoctor, src => src.MapFrom(y => y.IdOfSelectedSpecialist));
        }
    }
}
