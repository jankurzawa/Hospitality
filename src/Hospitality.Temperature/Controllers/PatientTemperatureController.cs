namespace PatientTemperatureControl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientTemperatureController : ControllerBase
    {
        private readonly ITemperaturesService _temperaturesService;

        public PatientTemperatureController(ITemperaturesService temperaturesService)
            => _temperaturesService = temperaturesService;

        [HttpGet("AllPatientTemperatures")]
        public async Task<ActionResult<List<PatientTemperaturesViewDTO>>> AllPatientTemperatures(string id)
        {
            var patientTemperatureViewDTO = await _temperaturesService.GetAllPatientTemperatures(id);
            if (patientTemperatureViewDTO is null)
                return NotFound();
            return patientTemperatureViewDTO;
        }

        [HttpPost("AddNewCurrentPatientTemperature")]
        public async Task<IActionResult> AddNewPatientTemperature(NewPatientTemperatureDTO newPatientTemperatureDTO)
        {
            await _temperaturesService.AddNewPatientTemperature(newPatientTemperatureDTO);
            return StatusCode(201);
        }
    }
}