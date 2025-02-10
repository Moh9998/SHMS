using System.ComponentModel.DataAnnotations;

namespace SHMS.Models;

public class TestResult
{
    [Key]
    public int Id
    {
        get; set;
    }

    [Required]
    public int PatientId
    {
        get; set;
    }

    [Required]
    public string TestName { get; set; } = string.Empty;

    [Required]
    public double Value
    {
        get; set;
    }  // Test result value

    [Required]
    public string Unit { get; set; } = string.Empty;

    public double NormalMin
    {
        get; set;
    } // Min normal value
    public double NormalMax
    {
        get; set;
    } // Max normal value

    public bool IsAbnormal => Value < NormalMin || Value > NormalMax; // Identify abnormal values

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
