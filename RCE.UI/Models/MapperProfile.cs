using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCE.UI.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductInvoiceModel, ProductCartModel>().ReverseMap();
        }
    }
}