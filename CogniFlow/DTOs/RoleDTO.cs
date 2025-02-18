using System.ComponentModel.DataAnnotations;

namespace CogniFlow.DTOs
{
    public class RoleDTO
    {
        [Required]  
        public string RoleName { get; set; }
    }
}
