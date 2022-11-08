namespace Hospitality.CheckUp.API.Service
{
    public class CheckUpService : ICheckUpService
    {
        private CheckUpContext CheckUpContext { get; set; }

        public CheckUpService(CheckUpContext checkUpContext)
            => CheckUpContext = checkUpContext;

        public async Task AddNewCheckUp(NewCheckUpDTO newCheckUpDTO)
        {
            if (newCheckUpDTO is null)
                throw new ResourceNotFoundException($"Check up cannot be empty");
            await CheckUpContext.CheckUps.AddAsync(new CheckUpModel
            {
                Description = newCheckUpDTO.Description,
                IdDoctor = newCheckUpDTO.IdDoctor,
                IdPatient = newCheckUpDTO.IdPatient,
                Time = DateTime.Now
            });
            CheckUpContext.SaveChanges();
        }
    }
}
