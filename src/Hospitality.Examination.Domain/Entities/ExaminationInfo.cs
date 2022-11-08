using Hospitality.Examination.Domain.Entities.Enums;

namespace Hospitality.Examination.Domain.Entities
{
    public class ExaminationInfo
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public ExaminationType Type { get; set; }
        public int ExaminationTypeId { get; set; }
        public ExaminationStatus Status { get; set; }
    }
}