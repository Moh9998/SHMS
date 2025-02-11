using System.ComponentModel.DataAnnotations;

namespace SHMS.Models
{
    public class Patient : User
    {
        [Required]
        public string MedicalRecordNumber { get; set; } = string.Empty;

        public ICollection<TestResult> TestResults { get; set; } = new List<TestResult>( );
    }
}
