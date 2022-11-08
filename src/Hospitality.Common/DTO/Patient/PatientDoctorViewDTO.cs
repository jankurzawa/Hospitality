namespace Hospitality.Common.DTO.Patient
{
    public record PatientDoctorViewDTO
    {
        [Required]
        public int HospitalPatientId { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string PatientName { get; init; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string PatientSurname { get; init; }

        [Required]
        [MinLength(11), MaxLength(11)]
        public string PatientPesel { get; init; }

        [Required]
        public DateTime BirthDate { get; init; }

        [DataType(DataType.Text)]
        public bool IsInsured { get; set; }

        public Guid IdOfSelectedDoctor { get; set; }
    }
}