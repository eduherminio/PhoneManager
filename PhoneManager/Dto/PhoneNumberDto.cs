using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneManager.Dto
{
    /// <summary>
    /// PhoneNumber Data Transfer Object
    /// </summary>
    public class PhoneNumberDto
    {
        [Required]
        public Guid CustomerId { get; set; }

        public ICollection<string> PhoneNumber { get; set; }

        public PhoneNumberDto()
        {
            PhoneNumber = new HashSet<string>();
        }
    }
}
