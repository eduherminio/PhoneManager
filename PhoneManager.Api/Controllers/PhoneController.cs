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

        /// <summary>
        /// Activates or updates one or multiple phone numbers for the same customer
        /// </summary>
        /// <param name="phoneNumberDto">Object with phone numbers and customr information</param>
        /// <returns></returns>
        [HttpPost]
        public PhoneNumberDto Activate([FromBody] PhoneNumberDto phoneNumberDto)
        {
            return _phoneNumberManager.Activate(phoneNumberDto);
        }

        /// <summary>
        /// Loads all phone numbers from all costumers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ICollection<PhoneNumberDto> LoadAll()
        {
            return _phoneNumberManager.LoadAll();
        }

        /// <summary>
        /// Loads all phone numbers of a certain customer
        /// </summary>
        /// <param name="customerId">Target customer id</param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public PhoneNumberDto LoadByCustomerId(Guid customerId)
        {
            return _phoneNumberManager.FindByCustomer(customerId);
        }
    }
}
