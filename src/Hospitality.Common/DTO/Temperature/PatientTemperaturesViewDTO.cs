namespace Hospitality.Common.DTO.Temperature
{
    public class PatientTemperaturesViewDTO
    {
        public string PatientId { get; set; }
        public decimal Temperature { get; set; }
        public DateTime MeasurementDate { get; set; }
    }
}
