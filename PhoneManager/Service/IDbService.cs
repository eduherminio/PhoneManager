using PhoneManager.Dto;
using System;
using System.Collections.Generic;

namespace PhoneManager.Service
{
    /// <summary>
    /// Data access layer
    /// </summary>
    public interface IDbService
    {
        PhoneNumberDto AddorUpdate(PhoneNumberDto phoneNumberDto);

        ICollection<PhoneNumberDto> LoadAll();

        PhoneNumberDto FindByCustomerId(Guid customerId);
    }
}
