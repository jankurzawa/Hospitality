namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
    public class RegistrationController : Controller
    {
        private HttpClient _httpClient;
        private IMapper _mapper;
        private IInsuranceService _insuranceService;
        private readonly IConfiguration _configuration;
        private IIdentityService _identityService;

        public RegistrationController(IHttpClientFactory httpClientFactory, IMapper mapper, IInsuranceService insuranceService,
            IConfiguration configuration, IIdentityService identityService)
        {
            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
            _insuranceService = insuranceService;
            _configuration = configuration;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<IActionResult> Registration(PatientResultViewModel? Model, string? pesel)
        {
            ViewBag.PeselP = pesel;
            if (Model.Result == "valid")
                return View();
            else 
                ViewBag.Invalid = Model.Result;
            Model.Doctors = await _identityService.GetAllDoctorsNamesAndIds(HttpContext.Session.GetString("token"));
            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationPostAsync(PatientResultViewModel model, string peselInput)
        {
            model.PatientPesel = peselInput;
            model.Result = "valid";
            await RegisterNewPatient(model, _configuration["Paths:CreatePatient"]);
            return RedirectToAction("CheckPatient", "CheckPatient");
        }

        private async Task RegisterNewPatient(PatientResultViewModel model, string url)
        {
            PatientReceptionistViewDTO mapedPatient = _mapper.Map<PatientReceptionistViewDTO>(model);
            mapedPatient.IdOfSelectedSpecialist = await _identityService.GetIdOfSelectedDoctor(model.NameOfSelectedDoctor, HttpContext.Session.GetString("token"));
            mapedPatient.IsInsured = await _insuranceService.CheckHealthInsurance(mapedPatient.Id, HttpContext.Session.GetString("token"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync(url, (new StringContent(JsonConvert.SerializeObject(mapedPatient), Encoding.UTF8, "application/json")));
        }
    }
}