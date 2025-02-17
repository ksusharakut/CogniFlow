using CogniFlow.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace CogniFlow.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateOnly DateBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
