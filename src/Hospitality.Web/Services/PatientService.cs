namespace Hospitality.Web.Services
{
    public class PatientService : IPatientService
    {
        private HttpClient _httpClient;
        public PatientService(IHttpClientFactory httpClientFactory, IMapper mapper)
            => _httpClient = httpClientFactory.CreateClient();

        public async Task<int> GetIdOfPatient(string url, string token)
        {
            var patient = await GetPatient(url, token);
            if (patient is null) return 0;
            return patient.HospitalPatientId;
        } 

        public async Task<PatientDoctorViewDTO?> GetPatient(string url, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode || response is null) return null;
            var patientDoctorViewDTO = JsonConvert.DeserializeObject<PatientDoctorViewDTO>(await response.Content.ReadAsStringAsync());
            if (patientDoctorViewDTO is null) return null;
            return patientDoctorViewDTO;
        }
    }
}
