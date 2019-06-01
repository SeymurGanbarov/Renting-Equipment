using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCE.Application.Repositories;
using RCE.Domain;
using RCE.Infrastructure.Repositories;
using System;

namespace REC.Core.Tests.Repositories
{
    [TestClass]
    public class UserToProductRepositoryTestClass
    {
        private IUserToProductRepository _userToProductRepository;

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
            _userToProductRepository = new UserToProductRepository();
        }

        [TestMethod]
        public void UserToProduct_Crud_Test()
        {
            //Arrange
            var userToProduct = new UserToProduct
            {
                 Amount=125,
                 CreatedDate=DateTime.Now,
                 UserId=Guid.NewGuid(),
                 ProductId=Guid.NewGuid()
            };

            //Act
            var addedItem= _userToProductRepository.Save(userToProduct);

            //Assert
            Assert.AreEqual(userToProduct.Amount, addedItem.Amount);
            Assert.AreEqual(userToProduct.CreatedDate, userToProduct.CreatedDate);
            Assert.AreEqual(userToProduct.UserId, userToProduct.UserId);
            Assert.AreEqual(userToProduct.ProductId, userToProduct.ProductId);

            //Act
            var item = _userToProductRepository.FindById(addedItem.Id);

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(userToProduct.UserId, item.UserId);
            Assert.AreEqual(userToProduct.ProductId, item.ProductId);
            Assert.AreEqual(addedItem.Id, item.Id);

            //Arrange
            item.Amount = 250;

            //Act
            var updatedItem = _userToProductRepository.Save(item);

            //Assert
            Assert.AreEqual(item.Id, updatedItem.Id);
            Assert.AreEqual(item.Amount, updatedItem.Amount);

            //Act
            _userToProductRepository.Remove(item.Id);
            var removedItem = _userToProductRepository.FindById(item.Id);

            //Assert
            Assert.IsNull(removedItem);
            Assert.AreNotEqual(item.Id, removedItem?.Id);
        }
    }
}
