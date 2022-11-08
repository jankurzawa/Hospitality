namespace Hospitality.Web.Controllers
{
    public class ExaminationController : Controller
    {
        private HttpClient _httpClient;
        private IExaminationService _examinationService;
        private IPatientService _patientService;
        private readonly IConfiguration _configuration;

        public ExaminationController(IHttpClientFactory httpClientFactory, IExaminationService examinationService, 
            IPatientService patientService, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _examinationService = examinationService;
            _patientService = patientService;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Examination(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
        {
            patientDataCheckUpViewModel.AvailableExaminations = (await _examinationService.GetAvailableExaminations(
                HttpContext.Session.GetString("token"))).Select(x => x.Name).ToList();
            return View(patientDataCheckUpViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> OrderAnExamination(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
        {
            if (!string.IsNullOrEmpty(patientDataCheckUpViewModel.ChosenExamination))
                await AssignIdOfChosenExamination(patientDataCheckUpViewModel);
            if (!string.IsNullOrEmpty(patientDataCheckUpViewModel.PatientPesel))
                await AssignIdOfPatient(patientDataCheckUpViewModel);
            await SendOrder(patientDataCheckUpViewModel, _configuration["Paths:CreateExamination"]);
            return Content(@"<script>window.close();</script>", "text/html");
        }

        private async Task AssignIdOfPatient(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
            => patientDataCheckUpViewModel.PatientId = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"] 
                + patientDataCheckUpViewModel.PatientPesel, HttpContext.Session.GetString("token"));
        private async Task AssignIdOfChosenExamination(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
            => patientDataCheckUpViewModel.ChosenExaminationId = (await _examinationService.GetAvailableExaminations(HttpContext.
                Session.GetString("token"))).Where(ae => ae.Name == patientDataCheckUpViewModel.ChosenExamination).FirstOrDefault().Id;
        private async Task SendOrder(PatientDataCheckUpViewModel patientDataCheckUpViewModel, string url)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(new CreateExaminationDto() 
            { ExaminationTypeId = patientDataCheckUpViewModel.ChosenExaminationId, PatientId = patientDataCheckUpViewModel.PatientId }), 
            Encoding.UTF8, "application/json"));
        }
    }
}
