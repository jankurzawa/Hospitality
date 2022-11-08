namespace Hospitality.Examination.Application.Mapper.Profiles
{
    public class ExaminationProfile : Profile
    {
        public ExaminationProfile()
        {
            CreateMap<ExaminationInfo, ExaminationInfoDto>()
                .ForMember(x => x.Status, e => e.MapFrom(m => m.Status.ToString()))
                .ForMember(x => x.TypeName, e => e.MapFrom(m => m.Type.Name));
            CreateMap<ExaminationType, ExaminationTypeDto>();
            CreateMap<AddNewExaminationCommand, ExaminationInfo>()
                .ForMember(x => x.Status, e => e.MapFrom(m => m.Status));
            CreateMap<ExaminationInfo, ExaminationExecutionDto>()
                .ForMember(x => x.Status, e => e.MapFrom(m => m.Status))
                .ForMember(x => x.Duration, e => e.MapFrom(m => m.Type.Duration))
                .ForMember(x => x.ExaminationTypeName, e => e.MapFrom(m => m.Type.Name));
        }
    }
}