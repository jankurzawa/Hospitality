namespace Hospitality.Patient.API.DAL
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientContext _context;
        public PatientRepository(PatientContext context)
            => _context = context;

        public async Task<HospitalPatient> GetByPesel(string pesel)
            => await _context.Patients.Where(p => pesel == p.PatientPesel).FirstOrDefaultAsync();
        
        public async Task<HospitalPatient> GetPatientByID(int patientID)
            => await _context.Patients.Where(p => p.HospitalPatientId == patientID).FirstOrDefaultAsync();

        public async Task<HospitalPatient> AddNewPatientAsync(HospitalPatient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
        public async Task UpdatePatient(HospitalPatient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}
