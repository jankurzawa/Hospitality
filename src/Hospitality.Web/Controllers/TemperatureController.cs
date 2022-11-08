namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class TemperatureController : Controller
    {
        private HttpClient _httpClient;
        private List<PatientTemperaturesViewDTO> patientTemperaturesViewDTO;
        private ITemperatureService _temperatureService;
        private readonly IConfiguration _configuration;

        public TemperatureController(IHttpClientFactory httpClientFactory, ITemperatureService temperatureService, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            patientTemperaturesViewDTO = new List<PatientTemperaturesViewDTO>();
            _temperatureService = temperatureService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> TemperatureControl(string patientPesel)
        {
            var patientTemperatures = await _temperatureService.GetPatientTemperatures(patientPesel, HttpContext.Session.GetString("token"));
            if (patientTemperatures != null)
                return View(patientTemperatures);
            
            patientTemperatures = new List<PatientTemperaturesViewDTO>() { new PatientTemperaturesViewDTO() {
                PatientId = patientPesel,
                Temperature = 0,
                MeasurementDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local) } };
            return View(patientTemperatures);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTemperatureToPatient(string actualPatientTemperature, string patientPesel)
        {
            if (!Decimal.TryParse(actualPatientTemperature, out decimal decimalValue))
                return Content(@"<script>alert(""Wrong property"");window.close();</script>", "text/html");
            
            string patientTemperatureWithDots = actualPatientTemperature.Replace(",", ".");
            NewPatientTemperatureDTO newPatientTemperatureDTO = new NewPatientTemperatureDTO()
            {
                PatientId = patientPesel,
                Temperature = Decimal.Parse(patientTemperatureWithDots)
            };
            await SaveNewTemperature(newPatientTemperatureDTO, _configuration["Paths:AddPatientTemperature"]);
            return Content(@"<script>window.close();</script>", "text/html");
        }

        private async Task SaveNewTemperature(NewPatientTemperatureDTO newPatientTemperatureDTO, string url)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newPatientTemperatureDTO), Encoding.UTF8, "application/json"));
        }
    }
}
