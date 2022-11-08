namespace Hospitality.Identity.API.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<List<DoctorDTO>> GetAllDoctorsNamesAndIds();
    }
}