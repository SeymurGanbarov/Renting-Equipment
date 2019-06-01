using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCE.Commons.Abstracts
{
    public interface IEntityBusinessLogic<T> where T:BaseEntityDTO 
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Save(T entity);
        void Remove(Guid id);
    }
}
