using RCE.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCE.UI.Models
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDTO> Products { get; set; }
        public IEnumerable<ProductTypeDTO> ProductTypes { get; set; }
    }
}