namespace Hospitality.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private ILogInService _logInService;
        private IDoctorService _doctorService;
        public IdentityController(ILogInService logInService, IDoctorService doctorService)
        {
            _logInService = logInService;
            _doctorService = doctorService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Credentials credentials)
        {
            var jwt = await _logInService.Login(credentials.email, credentials.password);
            if (jwt == null) return NoContent();
            return Ok(jwt);
        }

        [HttpGet("GetAllDoctorsNames")]
        public async Task<IActionResult> GetAllDoctorsNamesAndIds()
            => Ok(await _doctorService.GetAllDoctorsNamesAndIds());
    }
}
