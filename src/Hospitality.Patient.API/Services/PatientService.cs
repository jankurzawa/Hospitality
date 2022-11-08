namespace Hospitality.Patient.API.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task AddPatientAsync(PatientReceptionistViewDTO patientDTO)
        {
            if (patientDTO is null)
                throw new ResourceNotFoundException($"Patient cannot be empty");
            await _patientRepository.AddNewPatientAsync(new HospitalPatient
            {
                PatientName = patientDTO.PatientName,
                PatientSurname = patientDTO.PatientSurname,
                PatientPesel = patientDTO.PatientPesel,
                BirthDate = patientDTO.BirthDate,
                Address = patientDTO.Address,
                Email = patientDTO.Email,
                PhoneNumber = patientDTO.PhoneNumber,
                IsInsured = patientDTO.IsInsured,
                IdOfSelectedDoctor = patientDTO.IdOfSelectedSpecialist
            });
        }

        public async Task<PatientDoctorViewDTO> GetPatientByPeselAsync(string pesel)
        {
            if (pesel is null)
                throw new ResourceNotFoundException($"Pesel cannot be empty");
            var patient = await _patientRepository.GetByPesel(pesel);
            return _mapper.Map<PatientDoctorViewDTO>(patient);
        }

        public async Task<PatientNotificationDTO> GetPatientByIDAsync(int patientID)
        {
            if (patientID == 0)
                throw new ResourceNotFoundException($"Pesel cannot be empty");
            var patient = await _patientRepository.GetPatientByID(patientID);
            return _mapper.Map<PatientNotificationDTO>(patient);
        }

        public async Task UpdatePatient(UpdateAssinedDoctorOfPatientDTO patientDTO)
        {
            var patientToUpdate = await _patientRepository.GetByPesel(patientDTO.PatientPesel);
            patientToUpdate.IdOfSelectedDoctor = patientDTO.DoctorId;
            _patientRepository.UpdatePatient(patientToUpdate);
        }
    }
}
