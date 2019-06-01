using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCE.Application.Repositories;
using RCE.Domain;
using RCE.Infrastructure.Repositories;
using System;

namespace REC.Core.Tests.Repositories
{
    [TestClass]
    public class ProductRepositoryTestClass
    {
        private IProductRepository _productRepository;

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
                });
            }
            _productRepository = new ProductRepository();
        }

        [TestMethod]
        public void Product_Crud_Test()
        {
            //Arrange
            var product = new Product
            {
                Name = "KAMAZ",
                TypeId = Guid.NewGuid()
            };

            //Act
            var addedItem= _productRepository.Save(product);

            //Assert
            Assert.AreEqual(product.Name, addedItem.Name);
            Assert.AreEqual(product.TypeId, addedItem.TypeId);

            //Act
            var item = _productRepository.FindById(addedItem.Id);

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(product.TypeId, item.TypeId);
            Assert.AreEqual(addedItem.Id, item.Id);

            //Arrange
            item.Name = "BULDOZER";

            //Act
            var updatedItem = _productRepository.Save(item);

            //Assert
            Assert.AreEqual(item.Id, updatedItem.Id);
            Assert.AreEqual(item.Name, updatedItem.Name);

            //Act
            _productRepository.Remove(item.Id);
            var removedItem = _productRepository.FindById(item.Id);

            //Assert
            Assert.IsNull(removedItem);
            Assert.AreNotEqual(item.Id, removedItem?.Id);
        }
    }
}
