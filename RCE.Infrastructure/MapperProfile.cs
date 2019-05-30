using AutoMapper;
using RCE.Application.DTOs;
using RCE.Domain;
using RCE.Infrastructure.DAOs;

namespace RCE.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Product
            CreateMap<Product, ProductDAO>().ReverseMap();
            CreateMap<ProductDAO, ProductDTO>().ReverseMap();
            #endregion

            #region User
            CreateMap<User, UserDAO>().ReverseMap();
            CreateMap<UserDAO, UserDTO>().ReverseMap();
            #endregion

            #region PaymentType
            CreateMap<PaymentType, PaymentTypeDAO>().ReverseMap();
            CreateMap<PaymentTypeDAO, PaymentTypeDTO>().ReverseMap();
            #endregion

            #region ProductType
            CreateMap<ProductType, ProductTypeDAO>().ReverseMap();
            CreateMap<ProductTypeDAO, ProductTypeDTO>().ReverseMap();
            #endregion

            #region UserToProduct
            CreateMap<UserToProduct, UserToProductDAO>().ReverseMap();
            CreateMap<UserToProductDAO, UserToProductDTO>().ReverseMap();
            #endregion
        }
    }
}
