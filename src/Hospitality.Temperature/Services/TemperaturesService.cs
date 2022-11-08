namespace PatientTemperatureControl.Services
{
    public class TemperaturesService : ITemperaturesService
    {
        private readonly IMongoCollection<PatientTemperature> _temperaturesCollection;
        private readonly IConfiguration _configuration;

        public TemperaturesService(IOptions<PatientTemperaturesDatabaseSettings> temperaturesDatabaseSettings, IConfiguration configuration)
        {
            _configuration = configuration;
            _temperaturesCollection = new MongoClient(_configuration["connectionStringCosmos"]).GetDatabase(temperaturesDatabaseSettings.Value.DatabaseName)
                .GetCollection<PatientTemperature>(temperaturesDatabaseSettings.Value.TemperaturesCollectionName);
        }

        public async Task<List<PatientTemperaturesViewDTO>> GetAllPatientTemperatures(string id)
        {
            List<PatientTemperaturesViewDTO> patientTemperaturesViewDTO = new();
            List<PatientTemperature> patientTemperatures = await _temperaturesCollection.Find(x => x.PatientId == id).ToListAsync();
            foreach (var patientTemperature in patientTemperatures)
            {
                patientTemperaturesViewDTO.Add(new PatientTemperaturesViewDTO() { PatientId = patientTemperature.PatientId, Temperature = patientTemperature.Temperature, MeasurementDate = patientTemperature.MeasurementDate });
            }
            return patientTemperaturesViewDTO;
        }

        public async Task AddNewPatientTemperature(NewPatientTemperatureDTO newPatientTemperatureDTO)
            => await _temperaturesCollection.InsertOneAsync(new PatientTemperature()
            {
                PatientId = newPatientTemperatureDTO.PatientId,
                Temperature = newPatientTemperatureDTO.Temperature,
                MeasurementDate = DateTime.UtcNow
            });
    }
}