using PhoneManager.Dto;
using System;
using System.Collections.Generic;

namespace PhoneManager.Service
{
    public interface IDbService
    {
        PhoneNumberDto AddorUpdate(PhoneNumberDto phoneNumberDto);

        ICollection<PhoneNumberDto> LoadAll();

        PhoneNumberDto FindByCustomerId(Guid customerId);
    }
}
