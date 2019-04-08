using Moq;
using PhoneManager.Dto;
using PhoneManager.Service;
using PhoneManager.Service.Impl;
using System;
using Xunit;

namespace PhoneManager.Test
{
    public class PhoneNumberManagerTest
    {
        [Fact]
        public void Activate()
        {
            // Arrange
            Mock<IDbService> mock = new Mock<IDbService>();
            PhoneNumberDto fixture = new PhoneNumberDto();
            IPhoneNumberManager manager = new PhoneNumberManager(mock.Object);

            // Act
            manager.Activate(fixture);

            // Assert
            mock.Verify(m => m.AddorUpdate(fixture), Times.Once);
        }

        [Fact]
        public void LoadAll()
        {
            // Arrange
            Mock<IDbService> mock = new Mock<IDbService>();
            IPhoneNumberManager manager = new PhoneNumberManager(mock.Object);

            // Act
            manager.LoadAll();

            // Assert
            mock.Verify(m => m.LoadAll(), Times.Once);
        }

        [Fact]
        public void FindByCustomerId()
        {
            // Arrange
            Mock<IDbService> mock = new Mock<IDbService>();
            Guid customerId = Guid.NewGuid();
            IPhoneNumberManager manager = new PhoneNumberManager(mock.Object);

            // Act
            manager.FindByCustomer(customerId);

            // Assert
            mock.Verify(m => m.FindByCustomerId(customerId), Times.Once);
        }
    }
}
