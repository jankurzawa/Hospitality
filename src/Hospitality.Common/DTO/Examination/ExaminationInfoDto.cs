namespace Hospitality.Common.DTO.Examination
{
    public class ExaminationInfoDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public string TypeName { get; set; }
        public string Status { get; set; }
    }
}