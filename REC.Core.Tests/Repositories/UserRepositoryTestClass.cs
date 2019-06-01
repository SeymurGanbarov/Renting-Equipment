using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCE.Application.Repositories;
using RCE.Domain;
using RCE.Infrastructure.Repositories;
using System;

namespace REC.Core.Tests.Repositories
{
    [TestClass]
    public class UserRepositoryTestClass
    {
        private IUserRepository _userRepository;

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
            _userRepository = new UserRepository();
        }

        [TestMethod]
        public void User_Crud_Test()
        {
            //Arrange
            var user = new User
            {
                Name = "John",
                Email = "smith@gmail.com"
            };

            //Act
            var addedItem= _userRepository.Save(user);

            //Assert
            Assert.AreEqual(user.Name, addedItem.Name);
            Assert.AreEqual(user.Email, addedItem.Email);

            //Act
            var item = _userRepository.FindById(addedItem.Id);

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(user.Email, item.Email);
            Assert.AreEqual(addedItem.Id, item.Id);

            //Arrange
            item.Name = "Wick";

            //Act
            var updatedItem = _userRepository.Save(item);

            //Assert
            Assert.AreEqual(item.Id, updatedItem.Id);
            Assert.AreEqual(item.Name, updatedItem.Name);

            //Act
            _userRepository.Remove(item.Id);
            var removedItem = _userRepository.FindById(item.Id);

            //Assert
            Assert.IsNull(removedItem);
            Assert.AreNotEqual(item.Id, removedItem?.Id);
        }
    }
}
