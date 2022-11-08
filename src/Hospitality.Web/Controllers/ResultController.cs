namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class ResultController : Controller
    {
        private List<ExaminationInfoDto> examinationInfoDto;
        private IExaminationService _examinationService;

        public ResultController(IExaminationService examinationService)
        {
            examinationInfoDto = new List<ExaminationInfoDto>();
            _examinationService = examinationService;
        }

        [HttpPost]
        public async Task<IActionResult> Result(string patientId)
        {
            GetPatientExaminationsQuery getPatientExaminationsQuery = new GetPatientExaminationsQuery() { PatientId = int.Parse(patientId) };
            var patientExaminations = await _examinationService.GetPatientExaminations(getPatientExaminationsQuery, HttpContext.Session.GetString("token"));
            if (patientExaminations != null)
                return View(patientExaminations);
            examinationInfoDto = new List<ExaminationInfoDto>() { new ExaminationInfoDto(){TypeName="no examinations",
                Description="This patient dont have any examinations", Id=0 } };
            return View(examinationInfoDto);
        }
    }
}