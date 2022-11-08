namespace Hospitality.Examination.Application.Contracts.Persistence
{
    public interface IExaminationTypesRepository
    {
        Task<IEnumerable<ExaminationType>> GetAllExaminationTypesAsync();
    }
}