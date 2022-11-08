namespace Hospitality.CheckUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckUpController : ControllerBase
    {
        private readonly ICheckUpService _checkUpService;
        public CheckUpController(ICheckUpService checkUpService)
            => _checkUpService = checkUpService;

        [HttpPost]
        public async Task<ActionResult<NewCheckUpDTO>> AddNewCheckUp(NewCheckUpDTO newCheckUpDTO)
        {
            await _checkUpService.AddNewCheckUp(newCheckUpDTO);
            return StatusCode(201);
        }
    }
}