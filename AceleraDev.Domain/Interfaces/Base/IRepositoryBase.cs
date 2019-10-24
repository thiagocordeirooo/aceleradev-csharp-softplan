using System;
using System.Collections.Generic;

namespace AceleraDev.Domain.Interfaces.Base
{
    public interface IRepositoryBase<TModel> where TModel : class
    {
        void Add(TModel obj);
        void Update(TModel obj);
        void Remove(Guid id);
        TModel GetById(Guid id);
        IList<TModel> GetAll();
        IList<TModel> Find(Func<TModel, bool> predicate);
    }
}
