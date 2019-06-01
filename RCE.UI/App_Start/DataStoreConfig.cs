using RCE.Application.QueryServices;
using RCE.Application.Repositories;
using RCE.Domain;
using RCE.Infrastructure.QueryServices;
using RCE.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;

namespace RCE.UI.App_Start
{
    public static class DataStoreConfig
    {
        private readonly static IProductRepository _productRepository;
        private readonly static IUserRepository _userRepository;
        private readonly static IPaymentTypeRepository _paymentTypeRepository;
        private readonly static IProductTypeRepository _productTypeRepository;
        private readonly static IProductTypeQueryService _productTypeQueryService;

        static DataStoreConfig()
        {
            _productRepository = new ProductRepository();
            _userRepository = new UserRepository();
            _paymentTypeRepository = new PaymentTypeRepository();
            _productTypeRepository = new ProductTypeRepository();
            _productTypeQueryService = new ProductTypeQueryService();
        }

        public static void Initialize()
        {
            AddPaymentTypes();
            AddProductTypes();
            AddUser();
            AddProducts();
        }

        private static void AddPaymentTypes()
        {
            var paymentTypes = new List<PaymentType>
            {
                new PaymentType
                {
                    Type="OneTime",
                    Amount=100,
                    Currency="EUR",
                },
                 new PaymentType
                {
                    Type="Premium",
                    Amount=60,
                    Currency="EUR",
                },
                 new PaymentType
                 {
                     Type="Regular",
                     Amount=40,
                     Currency="EUR"
                 }
            };
            foreach (var item in paymentTypes)
            {
                _paymentTypeRepository.Save(item);
            }
        }

        private static void AddProductTypes()
        {
            var productTypes = new List<ProductType>
            {
                new ProductType
                {
                    Type="Heavy",
                    Point=2
                },
                new ProductType
                {
                    Type="Regular",
                    Point=1
                },
                new ProductType
                {
                    Type="Specialized",
                    Point=1
                }
            };
            foreach (var item in productTypes)
            {
                _productTypeRepository.Save(item);
            }
        }

        private static void AddUser()
        {
            var user = new User
            {
                Name = "John",
                Surname = "Wick",
                Email = "john@gmail.com",
                Password = Crypto.HashPassword("123")
            };
            _userRepository.Save(user);
        }

        private static void AddProducts()
        {
            var productTypes = _productTypeQueryService.GetAll();
           
            var hId = productTypes.FirstOrDefault(m => m.Type == "Heavy").Id;
            var rId = productTypes.FirstOrDefault(m => m.Type == "Regular").Id;
            var sId = productTypes.FirstOrDefault(m => m.Type == "Specialized").Id;

            var products = new List<Product>
            {
                new Product
                {
                    Name="KamAZ truck",
                    TypeId=rId,
                    PhotoPath="/UI/img/product-img/kamaz.jpg"
                },
                new Product
                {
                    Name="Caterpillar bulldozer",
                    TypeId=hId,
                    PhotoPath="/UI/img/product-img/buldozer.jpg"
                },
                new Product
                {
                    Name="Komatsu crane",
                    TypeId=hId,
                    PhotoPath="/UI/img/product-img/crane.jpg"
                },
                new Product
                {
                    Name="Volvo steamroller",
                    TypeId=rId,
                    PhotoPath="/UI/img/product-img/volvo.jpg"
                },
                new Product
                {
                    Name="Bosch jackhammer",
                    TypeId=sId,
                    PhotoPath="/UI/img/product-img/bosch.jpg"
                }
            };
            foreach (var item in products)
            {
                _productRepository.Save(item);
            }
        }
    }
}