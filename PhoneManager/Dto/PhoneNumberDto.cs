using System;
using System.Collections.Generic;

namespace PhoneManager.Dto
{
    public class PhoneNumberDto
    {
        public Guid CustomerId { get; set; }

        public ICollection<string> PhoneNumber { get; set; }

        public PhoneNumberDto()
        {
            PhoneNumber = new HashSet<string>();
        }
    }
}
