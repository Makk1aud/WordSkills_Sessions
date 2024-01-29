using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PatientForRegistrationDTO
    {
        [Required(ErrorMessage ="Firstname is required")]
        [Length(3, 20, ErrorMessage ="Incorrect Length")]
        public string? FirstName { get; init; }

        [Required(ErrorMessage = "LastName is required")]
        [Length(3, 30, ErrorMessage = "Incorrect Length")]
        public string? LastName { get; init; }

        [Required(ErrorMessage = "MiddleName is required")]
        [Length(3, 30, ErrorMessage = "Incorrect Length")]
        public string? MiddleName { get; init; }

        [Required(ErrorMessage = "Passport is required")]
        [Length(15, 20, ErrorMessage = "Incorrect Length")]
        public string? Passport { get; init; }

        [Required(ErrorMessage = "GenderId is required")]
        public int GenderId { get; init; }

        [Required(ErrorMessage = "Address is required")]
        [Length(20, 100, ErrorMessage = "Incorrect Length")]
        public string? Address { get; init; }

        [Required(ErrorMessage = "Phone is required")]
        [Length(16, 20, ErrorMessage = "Incorrect Length")]
        public string? Phone { get; init; }

        [Required(ErrorMessage = "Email is required")]
        [Length(3, 30, ErrorMessage = "Incorrect Length")]
        [EmailAddress(ErrorMessage ="Email is incorrect")]
        public string? Email { get; init; }

        [Length(10, 100, ErrorMessage = "WorkPlace Length")]
        public string? WorkPlace { get; init; }
    }
}
