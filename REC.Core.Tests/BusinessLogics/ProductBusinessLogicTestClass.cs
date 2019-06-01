using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RCE.Application.BusinessLogics;
using RCE.Application.DTOs;
using RCE.Application.QueryServices;
using RCE.Application.Repositories;
using RCE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REC.Core.Tests.BusinessLogics
{
    [TestClass]
    public class ProductBusinessLogicTestClass
    {
        private IProductBusinessLogic _productBusinessLogic;
        private List<ProductDTO> _products;

        [TestInitialize]
        public void Initialize()
        {
            try
            {
                Mapper.Configuration.AssertConfigurationIsValid();
            }
            catch (Exception)
            {
                Mapper.Initialize(config =>
                {
                    config.AddProfile<RCE.Application.MapperProfile>();
                });
            }
            _products = new List<ProductDTO>
            {
                new ProductDTO
                {
                    Id=Guid.NewGuid(),
                    CreatedDate=DateTime.Now,
                    Name="KAMAZ",
                    TypeId=Guid.NewGuid()
                },
                 new ProductDTO
                {
                    Id=Guid.NewGuid(),
                    CreatedDate=DateTime.Now,
                    Name="BULDOZER",
                    TypeId=Guid.NewGuid()
                }
            };
            var mockQueryService = new Mock<IProductQueryService>();
            mockQueryService.Setup(service => service.GetAll()).Returns(_products);
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(service => service.FindById(It.IsAny<Guid>())).Returns(Mapper.Map<Product>(_products[0]));
            mockRepository.Setup(service => service.Remove(It.IsAny<Guid>())).Callback((Guid id) =>
            {
                var removeItem = _products.FirstOrDefault(m => m.Id == id);
                _products.Remove(removeItem);
            });
            mockRepository.Setup(service => service.Save(It.IsAny<Product>())).Callback((Product item) =>
            {
                if(item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                    _products.Add(Mapper.Map<ProductDTO>(item));
                }
                else
                {
                    var entity = _products.FirstOrDefault(m => m.Id == item.Id);
                    entity.Name = item.Name;
                    entity.TypeId = item.TypeId;
                }
            });
            _productBusinessLogic = new BaseProductBusinessLogic(mockQueryService.Object,mockRepository.Object);
        }

        [TestMethod]
        public void Should_Get_AllProducts_After_GetByID()
        {
            //Arrange
            var expectedItem = _products.FirstOrDefault(m => m.Name == "KAMAZ");

            //Act
            var products= _productBusinessLogic.GetAll();
            var actualItem = products.FirstOrDefault(m => m.Name == "KAMAZ");

            //Assert
            Assert.AreEqual(_products.Count(), products.Count());
            Assert.AreEqual(expectedItem.Name,actualItem?.Name);

            //Act
            var selectedItem = _productBusinessLogic.GetById(expectedItem.Id);

            //Assert
            Assert.AreEqual(expectedItem.Name, selectedItem?.Name);
        }

        [TestMethod]
        public void Should_Save()
        {
            //Arrange
            var expectedItem = _products.FirstOrDefault(m => m.Name == "KAMAZ");
            expectedItem.Name = "MACHINE";

            //Act
            _productBusinessLogic.Save(expectedItem);
            var updatedItem = _products.FirstOrDefault(m => m.Id == expectedItem.Id);

            //Assert
            Assert.AreEqual(expectedItem.Id, updatedItem.Id);
            Assert.AreEqual(expectedItem.Name, updatedItem.Name);
        }

        [TestMethod]
        public void Should_Remove()
        {
            //Arrange
            var expectedItem = _products.FirstOrDefault(m => m.Name == "KAMAZ");

            //Act
            _productBusinessLogic.Remove(expectedItem.Id);
            var removedItem = _products.FirstOrDefault(m => m.Id == expectedItem.Id);

            //Assert
            Assert.IsNull(removedItem);

        }
    }
}
