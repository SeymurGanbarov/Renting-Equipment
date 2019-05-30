using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RCE.Application.BusinessLogics;
using RCE.Application.DTOs;
using RCE.Application.Services;
using RCE.Commons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REC.Core.Tests.Services
{
    [TestClass]
    public class ProductServiceTestClass
    {
        private Mock<IProductBusinessLogic> _mockProductService;
        private List<ProductDTO> _products;
        private ProductService _productService;

        [TestInitialize]
        public void Initialize()
        {
            _mockProductService = new Mock<IProductBusinessLogic>();

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
                }, new ProductDTO
                {
                    Id=Guid.NewGuid(),
                    CreatedDate=DateTime.Now,
                    Name="MACHINE",
                    TypeId=Guid.NewGuid()
                }
            };

            _mockProductService.Setup(service => service.GetAll()).Returns(_products);
            _mockProductService.Setup((service) => service.GetById(It.IsAny<Guid>())).Returns(_products.FirstOrDefault(m=>m.Name=="KAMAZ"));
            _mockProductService.Setup((service) => service.Remove(It.IsAny<Guid>()));
            _mockProductService.Setup((service) => service.Save(It.IsAny<ProductDTO>()))
                                                      .Callback((ProductDTO dto) =>
                                                      {
                                                          if (dto.Id == Guid.Empty)
                                                          {
                                                              dto.Id = Guid.NewGuid();
                                                              _products.Add(dto);
                                                          } 
                                                          else
                                                          {
                                                              var entity = _products.FirstOrDefault(m => m.Id == dto.Id);
                                                              entity.Name = dto.Name;
                                                              entity.TypeId = dto.TypeId;
                                                          }
                                                      });
            _productService = new ProductService(_mockProductService.Object);
        }

        [TestMethod]
        public void Should_Get_AllProducts()
        {
            //Arrange
            var actualId = _products.FirstOrDefault(m => m.Name == "KAMAZ")?.Id;

            //Act
            var result = _productService.GetAll();
            var excpectedId = result.Data?.FirstOrDefault(m => m.Name == "KAMAZ")?.Id;

            //Assert
            Assert.IsTrue(result.IsSucceed);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(result.Data.Count(), _products.Count());
            Assert.AreEqual(excpectedId, actualId);
        }

        [TestMethod]
        public void Should_GetProduct_ById()
        {
            //Arrange
            var actualId = _products.FirstOrDefault(m => m.Name == "KAMAZ").Id;

            //Act
            var result = _productService.GetById(actualId);

            //Assert
            Assert.IsTrue(result.IsSucceed);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(result.Data.Id, actualId);
        }

        [TestMethod]
        public void Should_Remove()
        {
            //Arrange
            var actualId = _products.FirstOrDefault(m => m.Name == "KAMAZ").Id;

            //Act
            var result = _productService.Remove(actualId);

            //Assert
            Assert.IsTrue(result.IsSucceed);
            _mockProductService.Verify(r => r.Remove(actualId));
        }

        [TestMethod]
        public void Should_Save()
        {
            //Arrange
            var typeId = Guid.NewGuid();
            var item = new ProductDTO
            {
                Name="TIR",
                TypeId= typeId,
            };

            //Act
            var result= _productService.Save(item);

            //Assert
            _mockProductService.Verify(r => r.Save(item));
            Assert.IsTrue(result.IsSucceed);
            Assert.AreEqual(_products.FirstOrDefault(m => m.Name == item.Name)?.TypeId, typeId);

            //Arrange
            var entity = _products.FirstOrDefault(m => m.Id == item.Id);
            entity.Name = "MIXER";

            //Act
            var response= _productService.Save(entity);

            //Assert
            Assert.IsTrue(response.IsSucceed);
            Assert.AreEqual(_products.FirstOrDefault(m => m.TypeId == typeId)?.Name, entity.Name);
        }

    }
}
