namespace PatientTemperatureControl.Models
{
    public class PatientTemperaturesDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TemperaturesCollectionName { get; set; } = null!;
    }
}
