using System.ComponentModel.DataAnnotations;

namespace Hospitality.CheckUp.API.DataBase.Entity
{
    public class CheckUpModel
    {
        [Key]
        public int CheckUpId { get; set; }
        public string Description { get; set; }
        public int IdPatient { get; set; }
        public Guid IdDoctor { get; set; }
        public DateTime Time { get; set; }
    }
}
