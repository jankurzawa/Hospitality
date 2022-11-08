namespace Hospitality.Common.DTO.Examination
{
    public class ExaminationExecutionDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public int ExaminationTypeId { get; set; }
        public string ExaminationTypeName { get; set; }
        public int Status { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
