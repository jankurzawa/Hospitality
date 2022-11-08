namespace Hospitality.Gateway.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ExaminationController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExaminationById(int id)
            => Ok(await _httpClient.GetStringAsync(_configuration["Paths:GetExaminationById"] + id));

        [HttpGet("TypesOfExaminations")]
        public async Task<IActionResult> GetListOfTypesExaminationAsync()
            => Ok(await _httpClient.GetStringAsync(_configuration["Paths:GetExaminationTypes"]));

        [HttpGet("PatientExaminationsResults")]
        public async Task<IActionResult> GetCurrentPatientExaminationsResultsAsync(int id)
            => Ok(await _httpClient.GetStringAsync(_configuration["Paths:GetPatientResult"] + id));

        [HttpPost]
        public async Task<IActionResult> AddNewExaminationAsync(CreateExaminationDto newExamination)
            => await GetContent(newExamination, _configuration["Paths:AddNewExamination"]);

        private async Task<IActionResult> GetContent(CreateExaminationDto newExamination, string url)
        {
            var response = await _httpClient.PostAsync(url, new StringContent(
                JsonConvert.SerializeObject(newExamination), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode || response is null) return NotFound();
            return NoContent(); ;
        }
    }
}