namespace Hospitality.Web.Models
{
    public class PatientResultViewModel
    {
        public string? Result { get; set; }

        [Required]
        [MinLength(3), MaxLength(40)]
        public string PatientName { get; set; }

        [Required]
        [MinLength(3), MaxLength(40)]
        public string PatientSurname { get; set; }

        [Required]
        [MinLength(11), MaxLength(11)]
        public string PatientPesel { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; } = DateTime.Now;

        [Required]
        [MinLength(3), MaxLength(100)]
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
        public List<DoctorDTO>? Doctors { get; set; } = new();
        [Required]
        public string NameOfSelectedDoctor { get; set; }
        public Guid IdOfSelectedDoctor { get; set; }
    }
}
