using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCE.Application.Repositories;
using RCE.Domain;
using RCE.Infrastructure.Repositories;
using System;
using System.Transactions;

namespace REC.Core.Tests.Repositories
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private IProductRepository _productRepository;

        [TestInitialize]
        public void Initialize()
        {
            _productRepository = new ProductRepository();
        }

        [TestMethod]
        public void Product_Crud_Test()
        {
            using (TransactionScope transaction=new TransactionScope())
            {
                var typeId = Guid.NewGuid();
                var product = new Product
                {
                    Name = "KAMAZ",
                    TypeId = typeId
                };
            }
        }
    }
}
