namespace Hospitality.Examination.Application.Functions.Examinations.Queries
{
    public class GetPatientExaminationsQuery : IRequest<List<ExaminationInfoDto>>
    {
        public int PatientId { get; set; }
    }
}