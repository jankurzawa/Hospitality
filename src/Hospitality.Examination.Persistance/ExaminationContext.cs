namespace Hospitality.Examination.API.Model
{
    public class ExaminationContext : DbContext
    {
        public DbSet<ExaminationInfo> Examinations { get; set; }
        public DbSet<ExaminationType> ExaminationTypes { get; set; }

        public ExaminationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExaminationType>()
                .Property(s => s.Duration)
                .HasConversion(new TimeSpanToTicksConverter());

            modelBuilder.SeedDatabase();
        }
    }
}