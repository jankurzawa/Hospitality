namespace Hospitality.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PatientController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor, Receptionist")]
        [HttpGet]
        public async Task<IActionResult> GetPatientByPeselAsync(string pesel)
            => Ok(await _httpClient.GetStringAsync(_configuration["Paths:GetPatientByPesel"] + pesel));

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
        [HttpPost]
        public async Task<IActionResult> RegisterNewPatientAsync(PatientReceptionistViewDTO newPatient)
            => await GetContentAsync(newPatient, _configuration["Paths:RegisterPatient"]);

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
        [HttpPut("UpdateAssinedDoctor")]
        public async Task<IActionResult> UpdateAssignedDoctor(UpdateAssinedDoctorOfPatientDTO patientDTO)
        {
            var response = await _httpClient.PutAsync(_configuration["Paths:UpdateAssinedDoctorOfPatient"], 
                new StringContent(JsonConvert.SerializeObject(patientDTO), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode || response is null) return NotFound();
            return NoContent();
        }
    
        private async Task<IActionResult> GetContentAsync(PatientReceptionistViewDTO newPatient, string url)
        {
            var response = await _httpClient.PostAsync(url, new StringContent(
                JsonConvert.SerializeObject(newPatient), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode || response is null) return NotFound(); ;
            return StatusCode(201);
        }
    }
}