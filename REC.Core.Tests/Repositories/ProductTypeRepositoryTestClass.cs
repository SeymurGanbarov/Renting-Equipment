using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCE.Application.Repositories;
using RCE.Domain;
using RCE.Infrastructure.Repositories;

namespace REC.Core.Tests.Repositories
{
    [TestClass]
    public class ProductTypeRepositoryTestClass
    {
        private IProductTypeRepository _productTypeRepository;

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
            _productTypeRepository = new ProductTypeRepository();
        }

        [TestMethod]
        public void ProductType_Crud_Test()
        {
            //Arrange
            var productType = new ProductType
            {
               Point=2,
               Type="Specialized"
            };

            //Act
            var addedItem = _productTypeRepository.Save(productType);

            //Assert
            Assert.AreEqual(productType.Type, addedItem.Type);
            Assert.AreEqual(productType.Point, addedItem.Point);

            //Act
            var item = _productTypeRepository.FindById(addedItem.Id);

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(productType.Type, item.Type);
            Assert.AreEqual(addedItem.Id, item.Id);

            //Arrange
            item.Type = "Specialized12";

            //Act
            var updatedItem = _productTypeRepository.Save(item);

            //Assert
            Assert.AreEqual(item.Id, updatedItem.Id);
            Assert.AreEqual(item.Type, updatedItem.Type);

            //Act
            _productTypeRepository.Remove(item.Id);
            var removedItem = _productTypeRepository.FindById(item.Id);

            //Assert
            Assert.IsNull(removedItem);
            Assert.AreNotEqual(item.Id, removedItem?.Id);
        }
    }
}
