namespace Hospitality.Examination.Domain.Entities
{
    public class ExaminationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public TimeSpan Duration { get; set; }
    }
}