namespace Hospitality.Common.DTO.Examination
{
    public class ExaminationTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public TimeSpan Duration { get; set; }
    }
}