namespace Hospitality.Examination.Application.Functions.Examinations.Commands
{
    public class AddNewExaminationCommandHandler : IRequestHandler<AddNewExaminationCommand, ExaminationInfoDto>
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IMapper _mapper;
        private IRabbitMqService _mqService;

        public AddNewExaminationCommandHandler(IExaminationRepository examinationRepository, IMapper mapper, IRabbitMqService mqService)
        {
            _examinationRepository = examinationRepository;
            _mapper = mapper;
            _mqService = mqService;
        }

        public async Task<ExaminationInfoDto> Handle(AddNewExaminationCommand request, CancellationToken cancellationToken)
        {
            var existingExamination = await _examinationRepository.GetExaminationByIdAsync((
                await _examinationRepository.AddNewExaminationAsync(_mapper.Map<ExaminationInfo>(request))).Id);
            _mqService.SendMessage(_mapper.Map<ExaminationExecutionDto>(existingExamination));
            return _mapper.Map<ExaminationInfoDto>(existingExamination);
        }
    }
}