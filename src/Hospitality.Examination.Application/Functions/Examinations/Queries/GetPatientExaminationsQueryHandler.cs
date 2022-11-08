namespace Hospitality.Examination.Application.Functions.Examinations.Queries
{
    public class GetPatientExaminationsQueryHandler : IRequestHandler<GetPatientExaminationsQuery, List<ExaminationInfoDto>>
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IMapper _mapper;

        public GetPatientExaminationsQueryHandler(IExaminationRepository examinationRepository, IMapper mapper)
        {
            _examinationRepository = examinationRepository;
            _mapper = mapper;
        }

        public async Task<List<ExaminationInfoDto>> Handle(GetPatientExaminationsQuery request, CancellationToken cancellationToken)
            => _mapper.Map<List<ExaminationInfoDto>>(await _examinationRepository.GetPatientExaminationsAsync(request.PatientId));
    }
}