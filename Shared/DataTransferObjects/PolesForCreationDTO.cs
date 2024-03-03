using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PolesForCreationDTO
    {
        [Required(ErrorMessage = "PolicyNum is required")]
        [Length(16, 16, ErrorMessage = "Incorrect Length")]
        public string? PolicyNum { get; init; }

        [Required(ErrorMessage = "EndDate is required")]        
        public DateTime? EndDate { get; set; }
    }
}
