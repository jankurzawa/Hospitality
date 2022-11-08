namespace Hospitality.Identity.API.Services.Interfaces
{
    public interface ILogInService
    {
        Task<string?> Login(string email, string password);
    }
}