using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PhoneManager.Dto;
using PhoneManager.Service;

namespace PhoneManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/phones")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneNumberManager _phoneNumberManager;

        public PhoneController(IPhoneNumberManager phoneNumberManager)
        {
            _phoneNumberManager = phoneNumberManager;
        }

        [HttpPost]
        public PhoneNumberDto Activate([FromBody] PhoneNumberDto phoneNumberDto)
        {
            return _phoneNumberManager.Activate(phoneNumberDto);
        }

        [HttpGet]
        public ICollection<PhoneNumberDto> LoadAllPhoneNumbers()
        {
            return _phoneNumberManager.LoadAll();
        }

        [HttpGet("{customerId}")]
        public PhoneNumberDto LoadByCustomerId(Guid customerId)
        {
            return _phoneNumberManager.FindByCustomer(customerId);
        }
    }
}
