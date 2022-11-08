namespace Hospitality.Examination.Application.Functions.ExaminationTypes.Queries.GetAllExaminationTypes
{
    public class GetAllExaminationTypesQueryHandler : IRequestHandler<GetAllExaminationTypesQuery, List<ExaminationTypeDto>>
    {
        private readonly IExaminationTypesRepository _examinationTypesRepository;
        private readonly IMapper _mapper;

        public GetAllExaminationTypesQueryHandler(IExaminationTypesRepository examinationTypesRepository, IMapper mapper)
        {
            _examinationTypesRepository = examinationTypesRepository;
            _mapper = mapper;
        }

        public async Task<List<ExaminationTypeDto>> Handle(GetAllExaminationTypesQuery request, CancellationToken cancellationToken)
            => _mapper.Map<List<ExaminationTypeDto>>(await _examinationTypesRepository.GetAllExaminationTypesAsync());
    }
}