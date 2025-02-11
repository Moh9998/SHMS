using System.ComponentModel.DataAnnotations;

namespace SHMS.Models
{
    public class Doctor : User
    {
        [Required]
        public string Specialty { get; set; } = string.Empty;

        public ICollection<Patient> Patients { get; set; } = new List<Patient>( );
    }
}
