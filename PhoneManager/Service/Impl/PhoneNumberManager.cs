using System;
using System.Collections.Generic;
using PhoneManager.Dto;

namespace PhoneManager.Service.Impl
{
    public class PhoneNumberManager : IPhoneNumberManager
    {
        private readonly IDbService _dbService;

        public PhoneNumberManager(IDbService dbService)
        {
            _dbService = dbService;
        }

        public PhoneNumberDto Activate(PhoneNumberDto phoneNumberDto) => _dbService.AddorUpdate(phoneNumberDto);

        public PhoneNumberDto FindByCustomer(Guid customerId) => _dbService.FindByCustomerId(customerId);

        public ICollection<PhoneNumberDto> LoadAll() => _dbService.LoadAll();
    }
}
