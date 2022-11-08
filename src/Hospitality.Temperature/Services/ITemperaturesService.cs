namespace PatientTemperatureControl.Services
{
    public interface ITemperaturesService
    {
        Task<List<PatientTemperaturesViewDTO>> GetAllPatientTemperatures(string id);
        Task AddNewPatientTemperature(NewPatientTemperatureDTO newPatientTemperatureDTO);
    }
}