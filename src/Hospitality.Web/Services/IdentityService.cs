namespace Hospitality.Web.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        private HttpClient _httpClient;
        public IdentityService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<DoctorDTO>> GetAllDoctorsNamesAndIds(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return JsonConvert.DeserializeObject<List<DoctorDTO>>(await (await _httpClient.GetAsync(
                _configuration["Paths:GetAllDoctorsNamesAndIds"])).Content.ReadAsStringAsync());
        }
        public async Task<Guid> GetIdOfSelectedDoctor(string nameOfSelectedDoctor, string token)
            => (await GetAllDoctorsNamesAndIds(token)).FirstOrDefault(d => d.Name == nameOfSelectedDoctor).Id;
    }
}
