namespace Hospitality.Patient.API.Data.Context
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options) { }

        public DbSet<HospitalPatient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.SeedPatientDb();
    }
}