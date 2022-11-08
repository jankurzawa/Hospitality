using Hospitality.Common.DTO.Temperature;

namespace Hospitality.Web.Services.Interfaces
{
    public interface ITemperatureService
    {

        Task<List<PatientTemperaturesViewDTO>> GetPatientTemperatures(string patientId, string token);
    }
}