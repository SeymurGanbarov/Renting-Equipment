using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCE.Commons.Abstracts
{
    public interface IEntityQueryService<T> where T:BaseEntityDTO
    {
        IEnumerable<T> GetAll();
    }
}
