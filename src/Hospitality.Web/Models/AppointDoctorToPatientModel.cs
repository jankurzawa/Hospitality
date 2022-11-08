namespace Hospitality.Web.Models
{
    public class AppointDoctorToPatientModel
    {
        [MinLength(11), MaxLength(11)]
        public string PatientPesel { get; set; }
        public List<DoctorDTO>? Doctors { get; set; } = new();
        public string SelectedDoctorName { get; set; }
        public Guid DoctorId { get; set; }
    }
}
