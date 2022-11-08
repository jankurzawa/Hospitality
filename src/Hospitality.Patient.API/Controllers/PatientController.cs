namespace Hospitality.Patient.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;
        public PatientController(IPatientService service)
            => _service = service;

        [HttpGet]
        [Route("Pesel")]
        public async Task<IActionResult> GetPatientByPeselAsync(string pesel)
            => Ok(await _service.GetPatientByPeselAsync(pesel));

        [HttpPost]
        public async Task<IActionResult> AddPatientAsync(PatientReceptionistViewDTO patientAddDTO)
        {
            await _service.AddPatientAsync(patientAddDTO);
            return Ok();
        }

        [HttpPut("UpdateAssignedDoctor")]
        public async Task<IActionResult> UpdateAssignedDoctor(UpdateAssinedDoctorOfPatientDTO patientDTO)
        {
            await _service.UpdatePatient(patientDTO);
            return NoContent();
        }
    }
}
