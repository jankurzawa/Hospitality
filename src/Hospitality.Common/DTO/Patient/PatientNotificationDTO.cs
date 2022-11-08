namespace Hospitality.Common.DTO.Patient
{
    public class PatientNotificationDTO
    {
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double Price { get; set; }
        public string ExaminationTypeName { get; set; } = "";
        public string ExaminationDescription { get; set; } = "";
        public bool IsInsured { get; set; }
        public int Status { get; set; } = 2;
    }
}
