namespace Hospitality.Patient.API.Data.Context
{
    public static class PatientSeed
    {
        public static void SeedPatientDb(this ModelBuilder builder)
        {
            List<HospitalPatient> patients = new();
            patients.Add(new HospitalPatient()
            {
                HospitalPatientId = 1,
                PatientName = "Aniela",
                PatientSurname = "Nowak",
                PatientPesel = "99112234543",
                BirthDate = new DateTime(1999, 11, 22),
                Address = "Wrzosowa",
                Email = "aniela.nowak@proton.me",
                PhoneNumber = "213769420",
                IsInsured = true,
            }); 
            
            patients.Add(new HospitalPatient()
            {
                HospitalPatientId = 2,
                PatientName = "Ania",
                PatientSurname = "Okrasa",
                PatientPesel = "98112234543",
                BirthDate = new DateTime(1998, 11, 22),
                Address = "Jaworowa",
                Email = "ania.okrasa@proton.me",
                PhoneNumber = "123456456",
                IsInsured = true,
            }); 

            patients.Add(new HospitalPatient()
            {
                HospitalPatientId = 3,
                PatientName = "Michał",
                PatientSurname = "Jakos",
                PatientPesel = "97112234543",
                BirthDate = new DateTime(1997, 11, 22),
                Address = "Fiołkowa",
                Email = "michal.jakos@proton.me",
                PhoneNumber = "456789123",
                IsInsured = true,
            }); 
            
            patients.Add(new HospitalPatient()
            {
                HospitalPatientId = 4,
                PatientName = "Olaf",
                PatientSurname = "Olal",
                PatientPesel = "98122255543",
                BirthDate = new DateTime(1998, 12, 22),
                Address = "Jaworowa",
                Email = "michal.jakos@proton.me",
                PhoneNumber = "999456456",
                IsInsured = false,
            }); 

            patients.Add(new HospitalPatient()
            {
                HospitalPatientId = 5,
                PatientName = "Dawid",
                PatientSurname = "Jac",
                PatientPesel = "97102233343",
                BirthDate = new DateTime(1997, 10, 22),
                Address = "Fiołkowa",
                Email = "ania.okrasa@proton.me",
                PhoneNumber = "458889123",
                IsInsured = true,
            }); 

            builder.Entity<HospitalPatient>().HasData(patients);
        }
    }
}
