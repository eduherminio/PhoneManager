using PhoneManager.Dto;
using System;
using System.Collections.Generic;

namespace PhoneManager.Service
{
    public interface IPhoneNumberManager
    {
        PhoneNumberDto Activate(PhoneNumberDto phoneNumberDto);

        ICollection<PhoneNumberDto> LoadAll();

        PhoneNumberDto FindByCustomer(Guid customerId);
    }
}
