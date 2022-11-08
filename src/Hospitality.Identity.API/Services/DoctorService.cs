namespace Hospitality.Identity.API.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private IMapper _mapper;

        public DoctorService(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<DoctorDTO>> GetAllDoctorsNamesAndIds()
            => _mapper.Map<List<DoctorDTO>>(await _userManager.GetUsersInRoleAsync("Doctor"));
    }
}
