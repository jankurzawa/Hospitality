namespace Hospitality.Examination.Persistance.Repositories
{
    public class ExaminationTypesRepository : IExaminationTypesRepository
    {
        private readonly ExaminationContext _context;

        public ExaminationTypesRepository(ExaminationContext context)
            =>_context = context;

        public async Task<IEnumerable<ExaminationType>> GetAllExaminationTypesAsync() 
            => await _context.ExaminationTypes.ToListAsync();
    }
}