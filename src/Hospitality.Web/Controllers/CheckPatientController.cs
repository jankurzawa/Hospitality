namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
    public class CheckPatientController : Controller
    {
        private readonly IConfiguration _configuration;
        private IPatientService _patientService;

        public CheckPatientController(IConfiguration configuration, IPatientService patientService)
        {
            _configuration = configuration;
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult CheckPatient()
            => View();

        [HttpPost]
        public async Task<IActionResult> CheckPatient(AppointDoctorToPatientModel modelpesel)
        {
            var patient = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"] 
                + modelpesel.PatientPesel, HttpContext.Session.GetString("token"));
            if (patient == 0) return RedirectToAction("Registration", "Registration", new { pesel = modelpesel.PatientPesel });
            return RedirectToAction("AssignDoctorToPatient", "AssignDoctorToPatient", new { pesel = modelpesel.PatientPesel }) ;
        }
    }
}
