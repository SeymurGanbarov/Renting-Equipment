using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCE.Application.Repositories;
using RCE.Domain;
using RCE.Infrastructure.Repositories;

namespace REC.Core.Tests.Repositories
{
    [TestClass]
    public class PaymentTypeRepositoryTestClass
    {
        private IPaymentTypeRepository _paymentTypeRepository;

        [TestInitialize]
        public void Initialize()
        {
            try
            {
                Mapper.Configuration.AssertConfigurationIsValid();
            }
            catch (System.Exception)
            {
                Mapper.Initialize(config =>
                {
                    config.AddProfile<RCE.Infrastructure.MapperProfile>();
                }); ;
            }

            
            _paymentTypeRepository = new PaymentTypeRepository();
        }

        [TestMethod]
        public void PaymentType_Crud_Test()
        {
            //Arrange
            var paymentType = new PaymentType
            {
                Amount = 100,
                Type = "One-Time"
            };

            //Act
            var addedItem = _paymentTypeRepository.Save(paymentType);

            //Assert
            Assert.AreEqual(paymentType.Type, addedItem.Type);
            Assert.AreEqual(paymentType.Amount, addedItem.Amount);

            //Act
            var item = _paymentTypeRepository.FindById(addedItem.Id);

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(paymentType.Type, item.Type);
            Assert.AreEqual(addedItem.Id, item.Id);

            //Arrange
            item.Type = "OneTime";

            //Act
            var updatedItem = _paymentTypeRepository.Save(item);

            //Assert
            Assert.AreEqual(item.Id, updatedItem.Id);
            Assert.AreEqual(item.Type, updatedItem.Type);

            //Act
            _paymentTypeRepository.Remove(item.Id);
            var removedItem = _paymentTypeRepository.FindById(item.Id);

            //Assert
            Assert.IsNull(removedItem);
            Assert.AreNotEqual(item.Id, removedItem?.Id);
        }
    }
}
