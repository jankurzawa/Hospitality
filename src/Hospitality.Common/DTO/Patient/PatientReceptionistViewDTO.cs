namespace Hospitality.Common.DTO.Patient
{
    public class PatientReceptionistViewDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string PatientName { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string PatientSurname { get; set; }

        [Required]
        [MinLength(11), MaxLength(11)]
        public string PatientPesel { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string Address { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(9), MaxLength(9)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        public bool IsInsured { get; set; }
        [Required]
        public Guid IdOfSelectedSpecialist { get; set; }
    }
}