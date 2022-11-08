
namespace Hospitality.Web.Services
{
    public class ExaminationService : IExaminationService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ExaminationService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        public async Task<List<ExaminationTypeDto>> GetAvailableExaminations(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(_configuration["Paths:GetTypesOfExaminations"]);
            if (!response.IsSuccessStatusCode || response is null)
                throw new Exception("Null response exception");
            var availableExaminations = JsonConvert.DeserializeObject<List<ExaminationTypeDto>>(await response.Content.ReadAsStringAsync());
            if (availableExaminations is null)
                throw new Exception("Null response exception");
            return availableExaminations;
        }

        public async Task<List<ExaminationInfoDto>> GetPatientExaminations(GetPatientExaminationsQuery getPatientExaminationsQuery, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(_configuration["Paths:PatientExaminationResults"] + 
                getPatientExaminationsQuery.PatientId);
            if (!response.IsSuccessStatusCode || response is null) return null;
            List<ExaminationInfoDto> examinationInfo = JsonConvert.DeserializeObject<List<ExaminationInfoDto>>(
                await response.Content.ReadAsStringAsync());
            if (examinationInfo is null) return null;
            return examinationInfo;
        }
    }
}