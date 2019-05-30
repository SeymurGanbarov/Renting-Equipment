using System;
using System.Collections.Generic;

namespace RCE.Commons.Abstracts
{
    public interface IEntityService<T> where T : BaseEntityDTO
    {
        LogicResult<IEnumerable<T>> GetAll();
        LogicResult<T> GetById(Guid id);
        LogicResult Save(T entity);
        LogicResult Remove(Guid id);
    }
}
