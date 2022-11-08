
namespace Hospitality.Examination.Application.Contracts.Persistence
{
    public interface IExaminationRepository
    {
        Task<ExaminationInfo> AddNewExaminationAsync(ExaminationInfo examination);
        Task<ExaminationInfo> GetExaminationByIdAsync(int id);
        Task<IEnumerable<ExaminationInfo>> GetPatientExaminationsAsync(int patientId);
        Task UpdateExaminationByNameAsync(ExaminationInfo examination);
    }
}