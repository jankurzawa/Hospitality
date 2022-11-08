namespace Hospitality.Patient.API.Data
{
    public class HospitalPatient
    {
        public int HospitalPatientId { get; set; } 
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientPesel { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsInsured { get; set; }
        public Guid IdOfSelectedDoctor { get; set; }
    }
}