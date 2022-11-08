namespace Hospitality.Examination.Application.Functions.Examinations.Queries
{
    public class GetExaminationByIdQueryHandler : IRequestHandler<GetExaminationByIdQuery, ExaminationInfoDto>
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IMapper _mapper;

        public GetExaminationByIdQueryHandler(IExaminationRepository examinationRepository, IMapper mapper)
        {
            _examinationRepository = examinationRepository;
            _mapper = mapper;
        }

        public async Task<ExaminationInfoDto> Handle(GetExaminationByIdQuery request, CancellationToken cancellationToken)
            => _mapper.Map<ExaminationInfoDto>(await _examinationRepository.GetExaminationByIdAsync(request.ExaminationId));
    }
}