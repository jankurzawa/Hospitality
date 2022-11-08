namespace Hospitality.Examination.Application.Functions.Examinations.Commands
{
    public class AddNewExaminationCommand : IRequest<ExaminationInfoDto>
    {
        public int PatientId { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public int ExaminationTypeId { get; set; }
    }
}