namespace Hospitality.Web.Services.Interfaces
{
    public interface IInsuranceService
    {
        Task<bool> CheckHealthInsurance(int idOfPerson, string token);
    }
}