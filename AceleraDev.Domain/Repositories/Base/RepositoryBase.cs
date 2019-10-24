using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AceleraDev.Domain.Repositories.Base
{
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : ModelBase
    {
        protected IList<TModel> _mock;

        public void Add(TModel obj)
        {
            _mock.Add(obj);
        }

        public IList<TModel> Find(Func<TModel, bool> predicate)
        {
            return _mock.Where(predicate).ToList();
        }

        public IList<TModel> GetAll()
        {
            return _mock;
        }

        public TModel GetById(Guid id)
        {
            return _mock.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(Guid id)
        {
            _mock.Remove(this.GetById(id));
        }

        public void Update(TModel obj)
        {
            this.Remove(obj.Id);
            this.Add(obj);
        }
    }
}
