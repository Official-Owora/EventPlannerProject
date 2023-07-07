using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.DTOs.ForCreationDto
{
    public class OrganizerForUpdateDto
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(15, ErrorMessage = "Maximum length for First Name is 15 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(15, ErrorMessage = "Maximum length for Last Name is 15 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100, ErrorMessage = "Maximum length for Email is 100 characters")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone number is required"), DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(5, ErrorMessage = "Maximum length for Password is 5 characters")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Role is compulsory")]
        public string? Role { get; set; }

    }
}
