namespace Hospitality.Common.DTO.Patient
{
    public class UpdateAssinedDoctorOfPatientDTO
    {
        public string PatientPesel { get; set; }
        public Guid DoctorId { get; set; }
    }
}
