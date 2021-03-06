﻿using System;

namespace RCE.Commons.Abstracts
{
    public interface IEntityRepository<T> where T: BaseEntity
    {
        T FindById(Guid id);
        void Remove(Guid id);
        T Save(T entity);
    }
}
