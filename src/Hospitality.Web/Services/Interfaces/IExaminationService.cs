using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.Application.Functions.Examinations.Queries;

namespace Hospitality.Web.Services.Interfaces
{
    public interface IExaminationService
    {
        Task<List<ExaminationTypeDto>> GetAvailableExaminations(string token);
        Task<List<ExaminationInfoDto>> GetPatientExaminations(GetPatientExaminationsQuery getPatientExaminationsQuery, string token);
    }
}