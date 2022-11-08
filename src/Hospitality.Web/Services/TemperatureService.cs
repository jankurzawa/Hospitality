namespace Hospitality.Web.Services
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class TemperatureService : ITemperatureService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TemperatureService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
        }
        public async Task<List<PatientTemperaturesViewDTO>> GetPatientTemperatures(string id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(_configuration["Paths:PatientTemperaturesList"] + id);
            if (!response.IsSuccessStatusCode || response is null) return null;
            List<PatientTemperaturesViewDTO> temperatureInfo = JsonConvert.DeserializeObject<List<PatientTemperaturesViewDTO>>(await response.Content.ReadAsStringAsync());
            if (temperatureInfo is null) return null;
            return temperatureInfo;
        }
    }
}
