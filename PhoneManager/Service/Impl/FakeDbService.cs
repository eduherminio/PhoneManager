using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using PhoneManager.Dto;

namespace PhoneManager.Service.Impl
{
    /// <summary>
    /// PoC, untested.
    /// Should probably receive Model entities rather data transfer objects
    /// </summary>
    public class FakeDbService : IDbService
    {
        private readonly ConcurrentDictionary<Guid, HashSet<string>> _dbMock = new ConcurrentDictionary<Guid, HashSet<string>>();

        public PhoneNumberDto AddorUpdate(PhoneNumberDto phoneNumberDto)
        {
            HashSet<string> addedPhoneNumber = _dbMock.AddOrUpdate(
                phoneNumberDto.CustomerId,
                (_) => new HashSet<string>(phoneNumberDto.PhoneNumber),
                (_, existingHashSet) =>
                {
                    foreach (string newPhoneNumber in phoneNumberDto.PhoneNumber)
                    {
                        existingHashSet.Add(newPhoneNumber);
                    }
                    return existingHashSet;
                });

            return new PhoneNumberDto()
            {
                CustomerId = phoneNumberDto.CustomerId,
                PhoneNumber = addedPhoneNumber
            };
        }

        public PhoneNumberDto FindByCustomerId(Guid customerId)
        {
            _dbMock.TryGetValue(customerId, out HashSet<string> phoneNumbers);

            return new PhoneNumberDto()
            {
                CustomerId = customerId,
                PhoneNumber = phoneNumbers ?? new HashSet<string>()
            };
        }

        public ICollection<PhoneNumberDto> LoadAll()
        {
            return ExtractAllPhoneNumbers().ToList();
        }

        private IEnumerable<PhoneNumberDto> ExtractAllPhoneNumbers()
        {
            foreach (var pair in _dbMock)
            {
                yield return new PhoneNumberDto()
                {
                    CustomerId = pair.Key,
                    PhoneNumber = pair.Value
                };
            }
        }
    }
}
