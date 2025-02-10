using System.ComponentModel.DataAnnotations;

namespace SHMS.Models;

    public class User
    {
        public int Id
        {
            get; set;
        }
        [Required]
        public string Name
        {
            get; set;
        }
        [Required, EmailAddress]
        public string Email
        {
            get; set;
        }
        [Required]
        public string PasswordHash
        {
            get; set;
        } // Store hashed password
        [Required]
        public UserRole Role
        {
            get; set;
        }
    }

    public enum UserRole
    {
        Doctor,
        Patient
    }

