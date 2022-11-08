namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class StartVisitController : Controller
    {
        private IPatientService _patientService;
        private IConfiguration _configuration;

        public StartVisitController(IPatientService patientService, IConfiguration configuration)
        {
            _patientService = patientService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult StartVisit(bool? result)
        {
            if (result == false) ViewBag.Show = "show";
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> StartVisit(PatientDataCheckUpViewModel model)
        {
            model.PatientId = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"]
                + model.PatientPesel, HttpContext.Session.GetString("token"));

            if (model.PatientId == 0)
                return RedirectToAction("StartVisit", "StartVisit", new { result = false });
            
            model.DoctorId = Guid.Parse(User.Claims.Where(x => x.Type == "Id").First().Value);
            if (!(await IfPatientIsAssignToLoggedDoctor(model)))
                return RedirectToAction("StartVisit", "StartVisit", model);

            return RedirectToAction("CheckUp", "CheckUp", model);
        }

        private async Task<bool> IfPatientIsAssignToLoggedDoctor(PatientDataCheckUpViewModel model)
            => (await _patientService.GetPatient(_configuration["Paths:GetPatientByPesel"] 
                + model.PatientPesel, HttpContext.Session.GetString("token"))).IdOfSelectedDoctor == model.DoctorId;
    }
}
