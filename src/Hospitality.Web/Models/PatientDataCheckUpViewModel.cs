namespace Hospitality.Web.Models
{
    public class PatientDataCheckUpViewModel
    {
        [MinLength(11), MaxLength(11)]
        public string PatientPesel { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public Guid DoctorId { get; set; }
        public string ChosenExamination { get; set; }
        public int ChosenExaminationId { get; set; }
        public List<string> AvailableExaminations { get; set; }
        public bool IsInsured { get; set; }
    }
}
