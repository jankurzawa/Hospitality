using Hospitality.Common.DTO.Patient;

namespace Hospitality.Web.Services.Interfaces
{
    public interface IPatientService
    {
        Task<int> GetIdOfPatient(string url, string token);
        Task<PatientDoctorViewDTO?> GetPatient(string url, string token);
    }
}