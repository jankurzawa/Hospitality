namespace Hospitality.CheckUp.API.DataBase.Context
{
    public class CheckUpContext : DbContext
    {
        public DbSet<CheckUpModel> CheckUps { get; set; }

        public CheckUpContext(DbContextOptions<CheckUpContext> options) : base(options) { }
    }
}
