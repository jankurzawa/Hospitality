namespace Hospitality.Patient.API.Services
{
    public interface IPatientService
    {
        Task<PatientDoctorViewDTO> GetPatientByPeselAsync(string pesel);
        Task AddPatientAsync(PatientReceptionistViewDTO patientDTO);
        Task<PatientNotificationDTO> GetPatientByIDAsync(int patientID);
        Task UpdatePatient(UpdateAssinedDoctorOfPatientDTO patientDTO);
    }
}