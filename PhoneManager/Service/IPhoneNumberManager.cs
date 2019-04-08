using PhoneManager.Dto;
using System;
using System.Collections.Generic;

namespace PhoneManager.Service
{
    /// <summary>
    /// Business logic layer
    /// </summary>
    public interface IPhoneNumberManager
    {
        /// <summary>
        /// Activates or updates one or multiple phone numbers for the same customer
        /// </summary>
        /// <param name="phoneNumberDto">Object with phone numbers and customr information</param>
        /// <returns></returns>
        PhoneNumberDto Activate(PhoneNumberDto phoneNumberDto);

        /// <summary>
        /// Loads all phone numbers of a certain customer
        /// </summary>
        /// <param name="customerId">Target customer id</param>
        ICollection<PhoneNumberDto> LoadAll();

        PhoneNumberDto FindByCustomer(Guid customerId);
    }
}
