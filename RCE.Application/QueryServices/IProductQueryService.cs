using RCE.Application.DTOs;
using RCE.Commons.Abstracts;

namespace RCE.Application.QueryServices
{
    public interface IProductQueryService : IEntityQueryService<ProductDTO>
    { }
}
