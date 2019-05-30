using AutoMapper;
using RCE.Application.DTOs;
using RCE.Domain;

namespace RCE.Application
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<PaymentTypeDTO, PaymentType>().ReverseMap();
            CreateMap<ProductTypeDTO, ProductType>().ReverseMap();
            CreateMap<UserToProductDTO, UserToProduct>().ReverseMap();
        }
    }
}
