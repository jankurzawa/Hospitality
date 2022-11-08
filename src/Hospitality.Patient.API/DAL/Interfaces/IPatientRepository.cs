namespace Hospitality.Patient.API.DAL.Interfaces
{
    public interface IPatientRepository
    {
        Task<HospitalPatient> GetByPesel(string pesel);
        Task<HospitalPatient> AddNewPatientAsync(HospitalPatient patient);
        Task<HospitalPatient> GetPatientByID(int id);
        Task UpdatePatient(HospitalPatient patient);
    }
}