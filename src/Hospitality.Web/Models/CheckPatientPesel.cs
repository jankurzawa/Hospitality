namespace Hospitality.Web.Models
{
    public class CheckPatientPesel
    {
        [MinLength(11), MaxLength(11)]
        public string PatientPesel { get; set; }
    }
}
