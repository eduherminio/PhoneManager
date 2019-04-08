using PhoneManager.Api.Test.Utils;
using PhoneManager.Dto;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace PhoneManager.Api.Test
{
    [Collection(PhoneManagerTestCollection.Name)]
    public class PhoneControllerTest
    {
        private readonly Fixture _fixture;
        private const string _baseUri = "api/phones";

        public PhoneControllerTest(Fixture fixture) => _fixture = fixture;

        [Fact]
        public void LoadAll()
        {
            // Arrange
            HttpClient client = _fixture.GetClient();
            Uri uri = _fixture.CreateUri(_baseUri);

            // Act
            ICollection<PhoneNumberDto> result = HttpHelper.Get<ICollection<PhoneNumberDto>>(client, uri, out HttpStatusCode statusCode);

            // Assert
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void LoadByCustomerId()
        {
            // Arrange
            HttpClient client = _fixture.GetClient();
            Guid customerId = Guid.NewGuid();
            Uri uri = _fixture.CreateUri($"{_baseUri}/{customerId}");

            // Act
            PhoneNumberDto result = HttpHelper.Get<PhoneNumberDto>(client, uri, out HttpStatusCode statusCode);

            // Assert
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotNull(result);
            Assert.Equal(customerId, result.CustomerId);
            Assert.Empty(result.PhoneNumber);
        }

        [Fact]
        public void Activate()
        {
            // Arrange
            HttpClient client = _fixture.GetClient();
            Uri uri = _fixture.CreateUri(_baseUri);
            PhoneNumberDto phoneNumberDto = new PhoneNumberDto()
            {
                CustomerId = Guid.NewGuid(),
                PhoneNumber = new List<string>()
            };

            // Act
            PhoneNumberDto result = HttpHelper.Post<PhoneNumberDto, PhoneNumberDto>(client, uri, phoneNumberDto, out HttpStatusCode statusCode);

            // Assert
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotNull(result);
            Assert.Equal(phoneNumberDto.CustomerId, result.CustomerId);
            Assert.Equal(phoneNumberDto.PhoneNumber, result.PhoneNumber);
        }
    }
}